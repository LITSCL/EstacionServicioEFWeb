using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionServicioEFModel.DAL
{
    public class EstacionServicioDAL
    {
        dbestacionservicioefwebEntities db = new dbestacionservicioefwebEntities();

        public void Save(EstacionServicio es)
        {
            db.EstacionServicio.Add(es);
            db.SaveChanges();
        }

        public List<EstacionServicio> GetAll()
        {
            return db.EstacionServicio.ToList();
        }

        public List<EstacionServicio> GetAll(int capacidadMinima)
        {
            List<EstacionServicio> estacionesServicio = db.EstacionServicio.ToList();
            if (capacidadMinima == 30)
            {
                return estacionesServicio.FindAll(es => es.CapacidadMaxima <= 39);
            }
            else
            {
                return estacionesServicio.FindAll(es => es.CapacidadMaxima > 39);
            }
        }

        public void Delete(int id)
        {
            EstacionServicio es = db.EstacionServicio.Find(id);
            db.EstacionServicio.Remove(es);
            db.SaveChanges();
        }

        public EstacionServicio Find(int id)
        {
            List<EstacionServicio> estacionesServicio = db.EstacionServicio.ToList();
            EstacionServicio estacionServicio = estacionesServicio.Find(es => es.Id == id);
            return estacionServicio;
        }

        public void Update(EstacionServicio es)
        {
            EstacionServicio estacionServicioBorrar = db.EstacionServicio.Find(es.Id);
            db.EstacionServicio.Remove(estacionServicioBorrar);
            db.EstacionServicio.Add(es);
            db.SaveChanges();
        }
    }
}
