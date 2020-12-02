using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TinTucDao
    {
        DuLich_DataBase db = null;
        public TinTucDao()
        {
            db = new DuLich_DataBase();
        }
        public long Them(TinTuc entity)
        {
            db.TinTucs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool CapNhat(TinTuc entity)
        {
            var tintuc = db.TinTucs.Find(entity.ID);
            tintuc.TieuDe = entity.TieuDe;
            tintuc.MoTa = entity.MoTa;
            tintuc.NoiDung = entity.NoiDung;
            tintuc.HinhAnh = entity.HinhAnh;
            tintuc.NgayDang = DateTime.Now;
            db.SaveChanges();
            return true;

        }
        public bool Xoa(int id)
        {
            try
            {
                var tintuc = db.TinTucs.Find(id);
                db.TinTucs.Remove(tintuc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<TinTuc> ListTinTuc()
        {
            return db.TinTucs.OrderByDescending(x => x.ID).ToList();
        }


        public TinTuc ViewDetail(int id)
        {
            return db.TinTucs.Find(id);
        }
        public TinTuc GetById(string tieude)
        {
            return db.TinTucs.SingleOrDefault(x => x.TieuDe == tieude);
        }
        public IEnumerable<TinTuc> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<TinTuc> model = db.TinTucs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.LoaiTT.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
