using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionServicioEFModel.DAL
{
    public class PuntoCargaDAL
    {
        dbestacionservicioefwebEntities db = new dbestacionservicioefwebEntities();

        public void Save(PuntoCarga pc)
        {
            db.PuntoCarga.Add(pc);
            db.SaveChanges();
        }

        public List<PuntoCarga> GetAll()
        {
            return db.PuntoCarga.ToList();
        }

        public List<PuntoCarga> GetAll(int capacidadMinima)
        {
            List<PuntoCarga> puntosCarga = db.PuntoCarga.ToList();
            if (capacidadMinima == 1)
            {
                return puntosCarga.FindAll(es => es.CapacidadMaxima <= 3);
            }
            else
            {
                return puntosCarga.FindAll(es => es.CapacidadMaxima > 3);
            }
        }

        public void Delete(int id)
        {
            PuntoCarga pc = db.PuntoCarga.Find(id);
            db.PuntoCarga.Remove(pc);
            db.SaveChanges();
        }

        public PuntoCarga Find(int id)
        {
            return db.PuntoCarga.Find(id);
        }

        public void Update(PuntoCarga pc)
        {
            PuntoCarga puntoCargaBorrar = db.PuntoCarga.Find(pc.Id);
            db.PuntoCarga.Remove(puntoCargaBorrar);
            db.PuntoCarga.Add(pc);
            db.SaveChanges();
        }
    }
}
