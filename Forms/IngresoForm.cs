﻿using Forms.Helpers;
using Libreria.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class IngresoForm : Form
    {
        private AdministracionManager _administracionManager;
        private bool _esAdmin;

        public IngresoForm(AdministracionManager administracionManager, bool esAdmin)
        {
            _administracionManager = administracionManager;
            _esAdmin = esAdmin;
            InitializeComponent();
        }

        private void IngresoForm_Load(object sender, EventArgs e)
        {
            EstablecerTexto();
        }

        private void EstablecerTexto()
        {
            var tituloForm = _esAdmin ? "ADMINISTRADOR" : "ESTUDIANTE";
            var labelUsuario = _esAdmin ? "Usuario" : "Legajo";

            this.lblTituloIngreso.Text = tituloForm;
            this.lblUsuario.Text = labelUsuario;

            this.lblTituloIngreso.Location = new Point((this.pnlIngreso.Width - this.lblTituloIngreso.Width) / 2, (this.pnlIngreso.Height - this.lblTituloIngreso.Height) / 2);
            this.lblTituloIngreso.Anchor = AnchorStyles.None;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                var ingresoValido = IngresoValido();
                if (!ingresoValido)
                {
                    MensajesHelper.MostrarListaErrores("Se encontraron los siguientes errores:");
                }
                else
                {
                    var loginvalido = LoginUsuario();
                    if(!loginvalido)
                    {
                        MensajesHelper.MostrarError("El login es invalido. Intente de nuevo.");
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MensajesHelper.MostrarException(ex);
            }
        }

        private bool IngresoValido()
        {
            var esValido = true;

            if (string.IsNullOrWhiteSpace(this.txtUsuario.Text))
            {
                var labelUsuario = _esAdmin ? "Usuario" : "Legajo";
                MensajesHelper.Errores.Add($"{labelUsuario} es obligatorio y no puede tener espacios.");
                esValido = false;
            }

            if (string.IsNullOrWhiteSpace(this.txtClave.Text))
            {
                MensajesHelper.Errores.Add($"La clave es obligatoria y no puede tener espacios.");
                esValido = false;
            }

            return esValido;
        }

        private bool LoginUsuario()
        {
            var usuario = this.txtUsuario.Text;
            var clave = this.txtClave.Text;

            return _administracionManager.LoginUsuario(usuario, clave, _esAdmin);
        }
    }
}