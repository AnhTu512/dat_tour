using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DichVuDao
    {
        DuLich_DataBase db = null;
        public DichVuDao()
        {
            db = new DuLich_DataBase();
        }
        public long Them(DichVu entity)
        {
            db.DichVus.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool CapNhat(DichVu entity)
        {
            var dichvu = db.DichVus.Find(entity.ID);
            dichvu.TenDichVu = entity.TenDichVu;
            dichvu.MoTaChiTiet = entity.MoTaChiTiet;
            dichvu.Images = entity.Images;
            dichvu.TinhTrang = entity.TinhTrang;
            db.SaveChanges();
            return true;

        }
        public bool Xoa(int id)
        {
            try
            {
                var dichvu = db.DichVus.Find(id);
                db.DichVus.Remove(dichvu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public DichVu ViewDetail(int id)
        {
            return db.DichVus.Find(id);
        }
        public DichVu GetById(string tendichvu)
        {
            return db.DichVus.SingleOrDefault(x => x.TenDichVu == tendichvu);
        }
        public IEnumerable<DichVu> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DichVu> model = db.DichVus;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenDichVu.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
