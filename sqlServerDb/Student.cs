﻿using System.Data;
using System.Data.SqlClient;

namespace SqlServerDb
{
    public class Student : Connection
    {
        public DataSet GetStudentSubjects(string email)
        {
            string query = $"select gc.codigoasig from EstudiantesGrupo eg, GruposClase gc where eg.Grupo = gc.codigo and eg.Email = '{email}';";

            SqlCommand c = createCommand(query);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }

        public DataSet GetStudentTasks(string email, string subjectCode)
        {
            string columns = "tg.Codigo, tg.Descripcion, tg.CodAsig, tg.HEStimadas";
            string query = $"select {columns} from TareasGenericas tg where CodAsig = '{subjectCode}' except select {columns} from TareasGenericas tg inner join EstudiantesTareas et on tg.Codigo = et.CodTarea where CodAsig = '{subjectCode}' and et.Email = '{email}';";

            SqlCommand c = createCommand(query);
            SqlDataAdapter da = new SqlDataAdapter(c);
            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;
        }
    }
}
