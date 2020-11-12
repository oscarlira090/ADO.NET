using BUSINESS_DATA_ACCESS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_DATA_MODEL
{
    public class Model
    {
	    public string id { get; set; }
        public string nombre { get; set; }

        public void add()
        {
            DB db = new DB();
            try
            {
                db.execNonQuery("INSERT INTO Model(nombre) values(@0)", this.nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.close();
            }
        }

        public void update()
        {
            DB db = new DB();
            try
            {
                db.execNonQuery("UPDATE Model set nombre = @0 WHERE id =@1", this.nombre, this.id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.close();
            }
        }

        public void delete()
        {
            DB db = new DB();
            try
            {
                db.execNonQuery("UPDATE Model set activo = @0 WHERE id =@1", false, this.id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.close();
            }
        }

        public static DataSet get()
        {
            DB db = new DB();
            DataSet ds = null;
            try
            {
                ds = db.GetDataSet("select id,nombre from Model");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.close();
            }

            return ds;
        }

        public static Model find(int id)
        {
            DB db = new DB();
            try
            {
                DataSet ds = db.GetDataSet("SELECT * FROM Model where id=@0", id);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    Model cd = new Model();
                    cd.id = int.Parse(dr["id"].ToString());
                    cd.nombre = dr["nombre"].ToString();
                    return cd;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.close();
            }
            
            return new Model();
        }
    }
}
