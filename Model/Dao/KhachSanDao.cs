using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhachSanDao
    {
        DuLich_DataBase db = null;
        public KhachSanDao()
        {
            db = new DuLich_DataBase();
        }
        public long Them(KhachSan entity)
        {
            db.KhachSans.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool CapNhat(KhachSan entity)
        {
            var khachsan = db.KhachSans.Find(entity.ID);
            khachsan.TenKhachSan = entity.TenKhachSan;
            khachsan.DiaChi = entity.DiaChi;
            khachsan.DonGia = entity.DonGia;
            khachsan.Images = entity.Images;
            khachsan.TinhTrang = entity.TinhTrang;
            khachsan.LoaiKhachSan = entity.LoaiKhachSan;
            db.SaveChanges();
            return true;

        }
        public bool Xoa(int id)
        {
            try
            {
                var khachsan = db.KhachSans.Find(id);
                db.KhachSans.Remove(khachsan);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public KhachSan ViewDetail(int id)
        {
            return db.KhachSans.Find(id);
        }
        public KhachSan GetById(string tenkhachsan)
        {
            return db.KhachSans.SingleOrDefault(x => x.TenKhachSan == tenkhachsan);
        }
        public IEnumerable<KhachSan> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<KhachSan> model = db.KhachSans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKhachSan.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
