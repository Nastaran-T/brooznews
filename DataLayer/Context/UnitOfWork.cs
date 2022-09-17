using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork:IDisposable
    {
        NewsContext db = new NewsContext();

        private IPageRepository _pageRepository;
        public IPageRepository PageRepository
        {
            get
            {
                if (_pageRepository == null)
                {
                    _pageRepository = new PageRepository(db);
                }
                return _pageRepository;
            }
        }

        private IPageGroupRepository _pageGroupRepository;
        public IPageGroupRepository pageGroupRepository
        {
            get
            {
                if (_pageGroupRepository==null)
                {
                    _pageGroupRepository = new PageGroupRepository(db);
                }
                return _pageGroupRepository;
            }
        }


        private IPageCommentRepository _pageCommentRepository;
        public IPageCommentRepository pageCommentRepository
        {
            get
            {
                if (_pageCommentRepository==null)
                {
                    _pageCommentRepository = new PageCommentRepository(db);
                }
                return _pageCommentRepository;
            }
        }


        private ILoginRepository _loginRepository;
        public ILoginRepository LoginRepository
        {
            get
            {
                if (_loginRepository == null)
                {
                    _loginRepository = new LoginRepository(db);
                }
                return _loginRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
