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
        ISimioProject currentProject;        
        //ISimioProject currentProject;
        IModel currentModel;
        IExperiment currentExperiment;

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
            for (int x = 1; x < lineas.Length - 1; x++)
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
                // ISimioProject _simioproject;
                string _projectPathAndFile = getPathActual();
                //MessageBox.Show(_projectPathAndFile);
                string[] warnings;
                currentProject = SimioProjectFactory.LoadProject("Model.spfx", out warnings);

                //ISimioProject project = SimioProjectFactory.LoadProject("Test.spfx", out warnings);
                IModel model = currentProject.Models["Model"];

                IExperiment experiment = model.Experiments.Create("Experiment");

                // Setup the experiment (optional)
                // Specify run times.
                //string experiment_ScenarioEnded = "2";
                double runtime = 2;
                IRunSetup setup = experiment.RunSetup;
                setup.StartingTime = new DateTime(2010, 10, 01);
                setup.WarmupPeriod = TimeSpan.FromHours(0);
                setup.EndingTime = experiment.RunSetup.StartingTime + TimeSpan.FromDays(runtime);
                experiment.ConfidenceLevel = ExperimentConfidenceLevelType.Point90;
                experiment.LowerPercentile = 5;
                experiment.UpperPercentile = 95;
                //model.Facility.IntelligentObjects["aeropuerto"].Properties["InitialCapacity"].Value = "69";
                int contador = 0;
                Random rnd = new Random();
                IFixedObject source = model.Facility.IntelligentObjects["fuente"] as IFixedObject;
                source.Properties["InterarrivalTime"].Value = "Random.Poisson(60/300)";
                foreach (var air in listaAeropuertos)
                {
                    TiempoServicioGeneral = rnd.Next(1, 3);

                    IFixedObject aeropuerto = model.Facility.IntelligentObjects.CreateObject("Server", new FacilityLocation(air.x, air.y, air.z)) as IFixedObject;
                    aeropuerto.ObjectName = air.nombre;
                    switch (TiempoServicioGeneral)
                    {
                        case 1:
                            aeropuerto.Properties["ProcessingTime"].Value = "Random.Triangular(35,45,60)";
                            break;
                        case 2:
                            aeropuerto.Properties["ProcessingTime"].Value = "Random.Triangular(30,40,50)";
                            break;
                        case 3:
                            aeropuerto.Properties["ProcessingTime"].Value = "Random.Uniform(30,50)";
                            break;                            
                    }
                    aeropuerto.Properties["FailureType"].Value = air.tipoFalla;
                    aeropuerto.Properties["OffShiftRule"].Value = "FinishWorkAlreadyStarted";
                    aeropuerto.Properties["CountBetweenFailures"].Value = air.cantEntreFallas.ToString();
                    aeropuerto.Properties["TimeToRepair"].Value = air.tiempoReparacion.ToString();

                    IFixedObject mezclador = model.Facility.IntelligentObjects.CreateObject("Combiner", new FacilityLocation(air.x, air.y+30, air.z)) as IFixedObject;
                    String n = air.nombre + "C";
                    mezclador.ObjectName = n;

                    IFixedObject sourceAviones = model.Facility.IntelligentObjects.CreateObject("Source", new FacilityLocation(air.x, air.y + 30, air.z)) as IFixedObject;
                    n = air.nombre + "S";
                    sourceAviones.ObjectName = n;
                    sourceAviones.Properties["InitialCapacity"].Value = "100";

                    IIntelligentObject pista = model.Facility.IntelligentObjects.CreateObject("Server", new FacilityLocation(air.x, air.y + 30, air.z));
                    n = air.nombre + "P";
                    pista.ObjectName = n;

                    pista.Properties["InitialCapacity"].Value = air.capacidadPista.ToString();
                    ILinkObject path1 = model.Facility.IntelligentObjects.CreateLink("TimePath", source.Nodes[0], aeropuerto.Nodes[0], null) as ILinkObject;
                    path1.Properties["TravelTime"].Value = air.tiempoAbordajeDespegue.ToString();
                    ILinkObject path = model.Facility.IntelligentObjects.CreateLink("Path", sourceAviones.Nodes[0], mezclador.Nodes[0], null) as ILinkObject;
                    ILinkObject path3 = model.Facility.IntelligentObjects.CreateLink("Path", aeropuerto.Nodes[0], mezclador.Nodes[1], null) as ILinkObject;





                    //nuevo.Properties[""].Value = air.tiempoPersonas;
                    //nuevo.Properties[""].Value = air.tiempoAbordajeDespegue;
                    //nuevo.Properties[""].Value = air.id;



                    //if (contador == 0)
                    //{

                    //    model.Facility.IntelligentObjects["DefaultEntity"].Properties["Name"].Value = air.nombre;

                    //}
                    //else
                    //{
                    //    model.Facility.IntelligentObjects["Server"+(contador+1)].Properties["Name"].Value = air.nombre;
                    //}

                    //model.Facility.IntelligentObjects[2].Properties["name"].Value = air.nombre;
                    contador = contador +1 ;
                }

                //model.Facility.IntelligentObjects.CreateObject("Server", new FacilityLocation(0, 0, 0));


                /*
                // Add event handler for events from experiment
                experiment.ScenarioEnded += new EventHandler<ScenarioEndedEventArgs>(experiment_ScenarioEnded);
                experiment.RunCompleted += new EventHandler<RunCompletedEventArgs>(experiment_RunCompleted);
                experiment.RunProgressChanged += new EventHandler<RunProgressChangedEventArgs>(experiment_RunProgressChanged);
                experiment.ReplicationEnded += new EventHandler<ReplicationEndedEventArgs>(experiment_ReplicationEnded);
                */
                // Run Experiment, will call event handler methods when finished etc.
                SimioProjectFactory.SaveProject(currentProject, "Nuevo.spfx", out warnings);                
                
            }
            else
            {
                MessageBox.Show("Debe cargar ambos archivos.");
            }
        }

        public void SetProject(string project, string model, string experiment)
        {
            // Set extension folder path
            //SimioProjectFactory.SetExtensionsPath(Directory.GetCurrentDirectory().ToString());

            // Open project
            string[] warnings;
            currentProject = SimioProjectFactory.LoadProject(project, out warnings);
            if (model != null || model != "")
            {
                SetModel(model);
                SetExperiment(experiment);
                //return currentProject;
            }
            //return null;
        }

        public ISimioProject GetCurrentProject()
        {
            return currentProject;
        }

        public void SetModel(string model)
        {
            if (currentProject != null)
            {
                currentModel = currentProject.Models[model];
                //return currentModel;
            }
            //return null;
        }

        public IModel GetCurrentModel()
        {
            return currentModel;
        }

        public void SetExperiment(string experiment)
        {
            currentExperiment = currentModel.Experiments[experiment];
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
