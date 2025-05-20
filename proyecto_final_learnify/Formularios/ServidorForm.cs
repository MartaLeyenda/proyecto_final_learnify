using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_final_learnify.Formularios
{
    public partial class ServidorForm : Form
    {
        private delegate void MostrarMensajeDelegate(string mensaje);

        private Socket servidorSocket;
        private Thread hiloPrincipal;
        private bool ejecutando = false;
        private List<StreamWriter> clientesConectados = new List<StreamWriter>();

        public ServidorForm()
        {
            InitializeComponent();
        }

        private void EnviarMensaje(string mensaje)
        {
            if (InvokeRequired)
            {
                Invoke(new MostrarMensajeDelegate(EnviarMensaje), mensaje);
            } else
            {
                txtLog.AppendText(mensaje + "\n");
            }
        }

        private void btnIniciar_click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPuerto.Text, out int puertoInicial) || puertoInicial < 1024 || puertoInicial > 65535)
            {
                MessageBox.Show("El puerto debe estar entre 1024 y 65535.");
                return;
            }

            int puerto = puertoInicial;
            bool servidorIniciado = false;

            while (!servidorIniciado && puerto <= 65535)
            {
                try
                {
                    IPEndPoint ie = new IPEndPoint(IPAddress.Any, puerto);
                    servidorSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    servidorSocket.Bind(ie);
                    servidorSocket.Listen(10);

                    ejecutando = true;
                    hiloPrincipal = new Thread(Escuchar);
                    hiloPrincipal.Start();

                    EnviarMensaje($"Servidor iniciado en puerto {puerto}");
                    txtPuerto.Text = puerto.ToString();
                    btnIniciar.Enabled = false;

                    servidorIniciado = true;
                }
                catch (SocketException)
                {
                    puerto++;
                }
            }

            if (!servidorIniciado)
            {
                MessageBox.Show("No se pudo iniciar el servidor en ningún puerto entre " + puertoInicial + " y 65535.");
            }
        }

        private void Escuchar()
        {
            while (ejecutando)
            {
                try
                {
                    Socket cliente = servidorSocket.Accept();
                    Thread hiloCliente = new Thread(AtenderCliente);
                    hiloCliente.Start(cliente);
                }
                catch { break; }
            }
        }

        private void AtenderCliente(object obj)
        {
            Socket socketCliente = (Socket)obj;
            IPEndPoint ie = (IPEndPoint)socketCliente.RemoteEndPoint;

            string rutaContraseña = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "contraseña.txt");
            string contraseña = File.Exists(rutaContraseña) ? File.ReadAllText(rutaContraseña).Trim() : "ProyectoLearnify2025";

            using (NetworkStream ns = new NetworkStream(socketCliente))
                using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns)) 
            {
                lock (clientesConectados)
                {
                    clientesConectados.Add(sw);
                }

                sw.WriteLine("Conectado al servidor TCP.");

                string linea;
                while ((linea = sr.ReadLine()) != null && ejecutando)
                {
                    string respuesta = ProcesarComando(linea, sw, contraseña);
                    if (respuesta != null)
                    {
                        sw.WriteLine(respuesta);
                    }
                }

                lock (clientesConectados)
                {
                    clientesConectados.Remove(sw);
                }
            }
            socketCliente.Close();
        }

        private string ProcesarComando(string comando, StreamWriter remitente, string contraseña)
        {
            comando = comando.Trim();

            if (comando.Equals("time", StringComparison.OrdinalIgnoreCase))
                return DateTime.Now.ToString("HH:mm:ss");

            if (comando.Equals("date", StringComparison.OrdinalIgnoreCase))
                return DateTime.Now.ToString("dd/MM/yyyy");

            if (comando.StartsWith("all ", StringComparison.OrdinalIgnoreCase))
            {
                string mensaje = comando.Substring(4);
                lock (clientesConectados)
                {
                    foreach (var cliente in clientesConectados)
                    {
                        if (cliente != remitente)
                        {
                            cliente.WriteLine("[ALL] " + mensaje);
                        }
                    }
                }
                return "[Tú] " + mensaje;
            }

            if (comando.StartsWith("close ", StringComparison.OrdinalIgnoreCase))
            {
                string clave = comando.Substring(6).Trim();
                if (clave == contraseña)
                {
                    EnviarMensaje("Servidor cerrado por comando.");
                    CloseServidor();
                    return "Servidor apagándose...";
                }
                else
                {
                    return "Contraseña incorrecta.";
                }
            }

            return "Comando no reconocido.";
        }

        private void CloseServidor()
        {
            ejecutando = false;
            servidorSocket.Close();
            hiloPrincipal.Abort();
            btnIniciar.Enabled = true;
        }

        private void ServidorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ejecutando = false;
            servidorSocket.Close();
        }
    }
}
