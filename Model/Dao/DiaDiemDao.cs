using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DiaDiemDao
    {
        DuLich_DataBase db = null;
        public DiaDiemDao()
        {
            db = new DuLich_DataBase();
        }
       public long Them(DiaDiem entity)
        {
            db.DiaDiems.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool CapNhat(DiaDiem entity)
        {
            var diadiem = db.DiaDiems.Find(entity.ID);
            diadiem.TenDiaDiem = entity.TenDiaDiem;
            diadiem.MotaChiTiet = entity.MotaChiTiet;
            diadiem.Images = entity.Images;
            db.SaveChanges();
            return true;

        }
        public bool Xoa(int id)
        {
            try
            {
                var diadiem = db.DiaDiems.Find(id);
                db.DiaDiems.Remove(diadiem);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<DiaDiem> ListDiaDiem()
        {
            return db.DiaDiems.OrderByDescending(x => x.ID).ToList();
        }
        public DiaDiem ViewDetail(int id)
        {
            return db.DiaDiems.Find(id);
        }
        public DiaDiem GetById(string tendiadiem)
        {
            return db.DiaDiems.SingleOrDefault(x => x.TenDiaDiem == tendiadiem);
        }
        public IEnumerable<DiaDiem> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DiaDiem> model = db.DiaDiems;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenDiaDiem.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
