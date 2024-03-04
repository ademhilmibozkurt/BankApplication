using BankApp.Web.Data.Entities;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Web.Controllers
{
    // MVC: Model-View-Controller
    // M: Models, brings information from database. 
    // V: Views, shows information to final user
    // C: Controllers, connects views and models

    // inheritance Controller class
    public class HomeController : Controller
    {
        // private readonly BankContext _context;
        // private readonly UserRepository userRepository;

        // private readonly IUserRepository _userRepository;
        private readonly IUow _uow;
        private readonly IUserMapper _userMapper;

        // DI
        public HomeController(IUserMapper userMapper, IUow uow)
        {
            // _context = context;
            // userRepository = new UserRepository(_context);
            //_userRepository = userRepository;
            _userMapper = userMapper;
            _uow = uow;
        }

        // Index.cshtml controller method
        public IActionResult Index()
        {
            // take users from context. (!) dont use. instead, use models
            // return View(_context.Users.ToList());

            //return View(_context.Users.Select(x =>
            //                new UserListModel
            //                {
            //                    Id = x.Id,
            //                    FirstName = x.FirstName,
            //                    LastName = x.LastName
            //                }).ToList());

            // return View(userRepository.GetAll());

            // return View(_userRepository.GetAll());

            // this scenario allows us to do not return directly an entity
            // *** models masks entities with mapping methodology *** 
            return View(_userMapper.MapToUserList(_uow.GetRepository<User>().GetAll()));
        }
    }
}
