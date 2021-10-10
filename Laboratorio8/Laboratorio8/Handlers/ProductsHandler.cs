
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Laboratorio8.Models;

namespace Laboratorio8.Handlers { 
    public class ProductsHandler
    {
        private SqlConnection conexion;
        private readonly string rutaConexion;

        public ProductsHandler()
        {
            rutaConexion = ConfigurationManager.ConnectionStrings["ConexionBaseDatos"].ToString();
            conexion = new SqlConnection(rutaConexion);
        }

        private DataTable CrearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new SqlCommand(consulta, conexion);
            SqlDataAdapter adaptadorParaTabla = new SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();

            conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            conexion.Close();
            return consultaFormatoTabla;
        }

        public IEnumerable<ProductsModel> GetAll()
        {
            IEnumerable<ProductsModel> productsList = null;
            List<ProductsModel> listaProductos = new List<ProductsModel>();

            string consulta = "SELECT * FROM dbo.Products";
            DataTable tablaResultado = CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                listaProductos.Add(
                    
                    new ProductsModel
                        {
                            idProducto = Convert.ToInt32(columna["id"]),
                            cantidad = Convert.ToInt32(columna["quantity"]),
                            nombre = Convert.ToString(columna["name"]),
                            precio = Convert.ToString(columna["price"])
                        }
                    
                );
            }
            productsList = listaProductos.AsEnumerable();
            
            return productsList;
        }
    }
}