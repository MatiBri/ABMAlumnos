using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMAlumnos
{
    class Alumno
    {
        string apellido;

        public string pApellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        string nombre;

        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        DateTime fechaNacimiento;

        public DateTime pFechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        int sexo;

        public int pSexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        int tipoDocumento;

        public int pTipoDocumento
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }
        int documento;

        public int pDocumento
        {
            get { return documento; }
            set { documento = value; }
        }
        string calle;

        public string pCalle
        {
            get { return calle; }
            set { calle = value; }
        }
        int numero;

        public int pNumero
        {
            get { return numero; }
            set { numero = value; }
        }
        bool actividad;

        public bool pActividad
        {
            get { return actividad; }
            set { actividad = value; }
        }
        bool casado;

        public bool pCasado
        {
            get { return casado; }
            set { casado = value; }
        }
        bool hijos;

        public bool pHijos
        {
            get { return hijos; }
            set { hijos = value; }
        }
        int cantidad;

        public int pCantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        int carrera;

        public int pCarrera
        {
            get { return carrera; }
            set { carrera = value; }
        }

        public string toString()
        {
            return apellido + ", " + nombre;
        }

    }
}
