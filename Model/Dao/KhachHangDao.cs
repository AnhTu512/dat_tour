using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class KhachHangDao
    {
        DuLich_DataBase db = null;
        public KhachHangDao()
        {
            db = new DuLich_DataBase();
        }
        public long Them(KhachHang entity)
        {
            db.KhachHangs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool CapNhat(KhachHang entity)
        {
            var khachhang = db.KhachHangs.Find(entity.ID);
            khachhang.TenKH = entity.TenKH;
            khachhang.SDT = entity.SDT;
            khachhang.Email = entity.Email;
            khachhang.DiaChi = entity.DiaChi;
            khachhang.SoNguoiLon = entity.SoNguoiLon;
            khachhang.SoTreEm = entity.SoTreEm;
            khachhang.NgayDi = entity.NgayDi;
            khachhang.YeuCau = entity.YeuCau;
            khachhang.TinhTrang = entity.TinhTrang;
            db.SaveChanges();
            return true;

        }
        public bool Xoa(int id)
        {
            try
            {
                var khachhang = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(khachhang);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public KhachHang ViewDetail(int id)
        {
            return db.KhachHangs.Find(id);
        }
        public KhachHang GetById(string tenkhachhang)
        {
            return db.KhachHangs.SingleOrDefault(x => x.TenKH == tenkhachhang);
        }
        public IEnumerable<KhachHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<KhachHang> model = db.KhachHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKH.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}
