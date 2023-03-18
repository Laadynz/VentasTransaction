﻿using AccesoDatos;
using System;
using System.Windows.Forms;

namespace VentasTransaction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Conexion.ConnectionString);
            Venta venta = new Venta();
            venta.CLienteId = 1;
            venta.Fecha = DateTime.Now;
            
            VentaDetalle producto1 = new VentaDetalle();
            producto1.ProductoId = 1;
            producto1.Cantidad = 1;
            producto1.Descripcion = "Azucar kg";
            producto1.PrecioUnitario = 27.00m;
            producto1.Importe = producto1.Cantidad * producto1.PrecioUnitario;

            VentaDetalle producto2 = new VentaDetalle();
            producto2.ProductoId = 2;
            producto2.Cantidad = 1;
            producto2.Descripcion = "Jugo Mango";
            producto2.PrecioUnitario = 10.00m;
            producto2.Importe = producto2.Cantidad * producto2.PrecioUnitario;

            venta.Conceptos.Add(producto1);
            venta.Conceptos.Add(producto2); 
        }
    }
}
