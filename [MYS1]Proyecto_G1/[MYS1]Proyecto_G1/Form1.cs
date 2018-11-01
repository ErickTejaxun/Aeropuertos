using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimioAPI;
using SimioAPI.Extensions;
using SimioAPI.Graphics;
using Simio;
using Simio.SimioEnums;

namespace _MYS1_Proyecto_G1
{
    public partial class Form1 : Form
    {
        public int TiempoServicioGeneral;
        public List<aeropuerto> listaAeropuertos = new List<aeropuerto>(); // ubicaciones.
        public List<vuelo> listaVuelos = new List<vuelo>(); // Rutas

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirArchivo(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cargarDestinos_Click(object sender, EventArgs e)
        {
            AbrirArchivo(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        public void AbrirArchivo(int flag)
        {
            OpenFileDialog navegadorArchivos = new OpenFileDialog();
            navegadorArchivos.Filter = "Archivo Excel|*.xlsx|Archivo Excel 2003|*.xls|Archivo separado por comas.|*.csv";
            navegadorArchivos.FilterIndex = 1;
            if (navegadorArchivos.ShowDialog() == DialogResult.OK)
            {
                string path = navegadorArchivos.FileName;
                path = path.Trim();
                cargarData(path, flag);
                //clases.carpeta nuevaCarpeta = new clases.carpeta(nombreNodo);                  
                //Console.WriteLine(textoArchivo);
            }
        }

        public void cargarData(String path, int flag)
        {
            // 0 aeropuertos
            // 1 Rutas
            char delimiter = '\\';
            String[] substrings = path.Split(delimiter);
            String nombreArchivo = "";
            foreach (var substring in substrings)
                nombreArchivo = substring;
            //Obtenemos la carpeta.            
            delimiter = '.';
            substrings = nombreArchivo.Split(delimiter);
            String type = "";
            foreach (var sub in substrings)
                type = sub;
            Console.WriteLine(type);
            if (type.Equals("xlsx"))
            {
                cargarPersonas(path);
            }
            else if (type.Equals("csv"))
            {
                if (flag == 0)
                {
                    cargarAeropuertos(path);
                }
                else if (flag == 1)
                {
                    cargarRutas(path);
                }
            }
        }

        public String getPathActual()
        {
            return System.IO.Path.GetDirectoryName(Application.ExecutablePath);
        }

        public void cargarPersonas(String path)
        {

        }
        public void cargarAeropuertos(String path)
        {
            string textoArchivo = System.IO.File.ReadAllText(@path);
            String[] lineas = textoArchivo.Split('\n');
            for(int x = 1; x < lineas.Length-1; x ++)            
            {
                String[] datos = lineas[x].Split(',');
                /*
                 id,nombre,posicion_x,posicion_y,posicion_z,tipo_falla,cantidad_eventos,tiempo_reparacion,aviones_por_pista,t_llegada_personas,t_abordaje
                1,Vietnam,0,-100,0,Processing Count Based,35,88,23,25,25
                 */
                listaAeropuertos.Add(new aeropuerto(datos[0], datos[1], Int32.Parse(datos[2]), Int32.Parse(datos[3]), Int32.Parse(datos[4]), datos[5], Int32.Parse(datos[6]),
                    Int32.Parse(datos[7]), Int32.Parse(datos[8]), Int32.Parse(datos[9]), Int32.Parse(datos[10])));
                this.dataUbicaciones.Rows.Add(datos[0], datos[1], Int32.Parse(datos[2]), Int32.Parse(datos[3]), Int32.Parse(datos[4]), datos[5], Int32.Parse(datos[6]),
                    Int32.Parse(datos[7]), Int32.Parse(datos[8]), Int32.Parse(datos[9]), Int32.Parse(datos[10]));
            }
            this.dataUbicaciones.Visible = true;
        }

        public void cargarRutas(String path)
        {
            string textoArchivo = System.IO.File.ReadAllText(@path);
            String[] lineas = textoArchivo.Split('\n');
            for (int x = 1; x < lineas.Length - 1; x++)
            {
                String[] datos = lineas[x].Split(',');
                /*
                a_destino,a_origen,costo,virajes_maximos,tiempo_esperado
                1,16,50,5,2.5
                string iddestino, string idorigen, double costokm, int virajesMaximo, int tiempoMaximo
                 */
                listaVuelos.Add(new vuelo(datos[0], datos[1], Double.Parse(datos[2]), Double.Parse(datos[3]), Double.Parse(datos[4].Trim())));
                this.dataVuelos.Rows.Add(datos[0], datos[1], Double.Parse(datos[2]), Double.Parse(datos[3]), Double.Parse(datos[4].Trim()));
            }
            this.dataVuelos.Visible = true;
        }

        private void calcularRutas_Click(object sender, EventArgs e)
        {
            analizar();
        }

        public void analizar()
        {
            if (listaAeropuertos.Count > 0 && listaVuelos.Count > 0)
            {
                ISimioProject _simioproject;
                string _projectPathAndFile = getPathActual();
                MessageBox.Show(_projectPathAndFile);
            }
            else
            {
                MessageBox.Show("Debe cargar ambos archivos.");
            }
        }
    }

    public class aeropuerto
    {
        public string id, nombre, tipoFalla;
        public int x, y, z, cantEntreFallas, tiempoReparacion
            , capacidadPista, tiempoPersonas, tiempoAbordajeDespegue;
        
        public aeropuerto(String id, String nombre, int x, int y, int z, String tipoFalla, int cantEntreFallas, int tiempoReparacion,
            int capacidadPista, int tiempoPersonas, int tiempoAbordajeDespegue)
        {
            this.id = id;
            this.nombre = nombre;
            this.x = x;
            this.y = y;
            this.z = z;
            this.cantEntreFallas = cantEntreFallas;
            this.tiempoReparacion = tiempoReparacion;
            this.tipoFalla = tipoFalla;
            this.capacidadPista = capacidadPista;
            this.tiempoPersonas = tiempoPersonas;
            this.tiempoAbordajeDespegue = tiempoAbordajeDespegue;
        }

    }

    public class vuelo
    {
        public String iddestino, idorigen;
        public double costokm;
        public double virajesMaximo, tiempoMaximo;

        public vuelo(string iddestino, string idorigen, double costokm, double virajesMaximo, double tiempoMaximo)
        {
            this.iddestino = iddestino;
            this.idorigen = idorigen;
            this.costokm = costokm;
            this.virajesMaximo = virajesMaximo;
            this.tiempoMaximo = tiempoMaximo;
        }
    }

     

}
