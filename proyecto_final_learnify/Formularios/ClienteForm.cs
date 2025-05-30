﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace proyecto_final_learnify.Formularios
{
    public partial class ClienteForm : Form
    {
        private TcpClient cliente;
        private StreamWriter sw;
        private StreamReader sr;
        public ClienteForm()
        {
            InitializeComponent();
        }

        private void btnConectar_click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            if (!IPAddress.TryParse(ip, out IPAddress direccionIP))
            {
                MessageBox.Show("IP inválida.");
                return;
            }

            if (!int.TryParse(txtPuerto.Text, out int puerto) || puerto < 1024 || puerto > 65535)
            {
                MessageBox.Show("Puerto inválido. Debe estar entre 1024 y 65535.");
                return;
            }

            try
            {
                cliente = new TcpClient(direccionIP.ToString(), puerto);
                using (NetworkStream ns = cliente.GetStream())
                using (StreamWriter sw2 = new StreamWriter(ns))
                using (StreamReader sr2 = new StreamReader(ns))
                {
                    sr = sr2;
                    sw = sw2;
                    sw2.AutoFlush = true;
                    txtMensajes.AppendText(sr2.ReadLine() + "\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar al servidor: " + ex.Message);
            }
        }

        private void btnEnviar_click(object sender, EventArgs e)
        {
            if (sw != null && sr != null)
            {
                string mensaje = txtEntrada.Text.Trim();
                sw.WriteLine(mensaje);

                string respuesta = sr.ReadLine();
                txtMensajes.AppendText(">> " + respuesta + "\n");
                txtEntrada.Clear();
            }
        }

        private void btnSalir_click(object sender, EventArgs e)
        {
            cliente.Close();
            this.Close();
        }
    }
}
