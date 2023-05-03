namespace VentasTransaction
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.icmClientes = new FontAwesome.Sharp.IconMenuItem();
            this.icmExistencias = new FontAwesome.Sharp.IconMenuItem();
            this.icmProductos = new FontAwesome.Sharp.IconMenuItem();
            this.icmVentas = new FontAwesome.Sharp.IconMenuItem();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.menutitulo.SuspendLayout();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // menutitulo
            // 
            this.menutitulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.icmClientes,
            this.icmExistencias,
            this.icmProductos,
            this.icmVentas});
            this.menutitulo.Location = new System.Drawing.Point(0, 48);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.Size = new System.Drawing.Size(552, 73);
            this.menutitulo.TabIndex = 2;
            this.menutitulo.Text = "menuStrip1";
            // 
            // icmClientes
            // 
            this.icmClientes.AutoSize = false;
            this.icmClientes.IconChar = FontAwesome.Sharp.IconChar.User;
            this.icmClientes.IconColor = System.Drawing.Color.Black;
            this.icmClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmClientes.IconSize = 40;
            this.icmClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.icmClientes.Name = "icmClientes";
            this.icmClientes.Size = new System.Drawing.Size(122, 69);
            this.icmClientes.Text = "Clientes";
            this.icmClientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.icmClientes.Click += new System.EventHandler(this.iconMenuItem4_Click);
            // 
            // icmExistencias
            // 
            this.icmExistencias.AutoSize = false;
            this.icmExistencias.IconChar = FontAwesome.Sharp.IconChar.E;
            this.icmExistencias.IconColor = System.Drawing.Color.Black;
            this.icmExistencias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmExistencias.IconSize = 40;
            this.icmExistencias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.icmExistencias.Name = "icmExistencias";
            this.icmExistencias.Size = new System.Drawing.Size(122, 69);
            this.icmExistencias.Text = "Existencias";
            this.icmExistencias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.icmExistencias.Click += new System.EventHandler(this.icmExistencias_Click);
            // 
            // icmProductos
            // 
            this.icmProductos.AutoSize = false;
            this.icmProductos.IconChar = FontAwesome.Sharp.IconChar.ProductHunt;
            this.icmProductos.IconColor = System.Drawing.Color.Black;
            this.icmProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmProductos.IconSize = 40;
            this.icmProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.icmProductos.Name = "icmProductos";
            this.icmProductos.Size = new System.Drawing.Size(122, 69);
            this.icmProductos.Text = "Productos";
            this.icmProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.icmProductos.Click += new System.EventHandler(this.icmProductos_Click);
            // 
            // icmVentas
            // 
            this.icmVentas.AutoSize = false;
            this.icmVentas.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.icmVentas.IconColor = System.Drawing.Color.Black;
            this.icmVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icmVentas.IconSize = 40;
            this.icmVentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.icmVentas.Name = "icmVentas";
            this.icmVentas.Size = new System.Drawing.Size(122, 69);
            this.icmVentas.Text = "Ventas";
            this.icmVentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.icmVentas.Click += new System.EventHandler(this.icmVentas_Click);
            // 
            // Menu
            // 
            this.Menu.AutoSize = false;
            this.Menu.BackColor = System.Drawing.Color.SteelBlue;
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Menu.Size = new System.Drawing.Size(552, 48);
            this.Menu.TabIndex = 3;
            this.Menu.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(22, 44);
            this.toolStripMenuItem1.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Punto de Venta";
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 121);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(552, 292);
            this.Contenedor.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 413);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menutitulo);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.menutitulo;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.menutitulo.ResumeLayout(false);
            this.menutitulo.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem icmExistencias;
        private FontAwesome.Sharp.IconMenuItem icmProductos;
        private FontAwesome.Sharp.IconMenuItem icmVentas;
        private FontAwesome.Sharp.IconMenuItem icmClientes;
        private System.Windows.Forms.Panel Contenedor;
    }
}

