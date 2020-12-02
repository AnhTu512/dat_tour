using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TaiKhoanDao
    {
        DuLich_DataBase db = null;
        public TaiKhoanDao()
        {
            db = new DuLich_DataBase();
        }
        #region Login 
        public int DangNhap(string userName, string passWord)
        {
            var result = db.TaiKhoans.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.UserPass == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        #endregion
        #region CRUD
        public long Them(TaiKhoan entity)
        {
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool CapNhat(TaiKhoan entity)
        {
            try
            {
                var user = db.TaiKhoans.Find(entity.ID);
                if (string.IsNullOrEmpty(entity.UserPass))
                {
                    user.UserPass = entity.UserPass;
                }
                user.Name = entity.Name;
                user.Status = entity.Status;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Xoa(int id)
        {
            try
            {
                var user = db.TaiKhoans.Find(id);
                db.TaiKhoans.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #region VIEW
        public TaiKhoan ViewDetail(int id)
        {
            return db.TaiKhoans.Find(id);
        }
        public TaiKhoan GetById(string username)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.UserName == username);
        }
        public IEnumerable<TaiKhoan> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<TaiKhoan> model = db.TaiKhoans;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString));
            }
            return model.OrderBy(x => x.ID).ToPagedList(page, pageSize);
        }
        #endregion
    }
}
