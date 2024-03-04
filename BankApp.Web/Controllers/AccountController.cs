using BankApp.Web.Data.Entities;
using BankApp.Web.Data.UnitOfWork;
using BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankApp.Web.Controllers
{
    public class AccountController : Controller
    {
        //// private readonly BankContext _context;
        //private readonly IUserRepository _userRepository;
        //private readonly IUserMapper _userMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IAccountMapper _accountMapper;

        //public AccountController(BankContext context, IUserRepository userRepository, IUserMapper userMapper, IAccountRepository accountRepository, IAccountMapper accountMapper)
        //{
        //    // _context = context;
        //    _userRepository = userRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}
        //public IActionResult Create(int id)
        //{
        //    // *** do not return entity directly. always use a model(usermodel) instead
        //    var userInfo = _userMapper.MapToUser(_userRepository.GetById(id));
        //    return View(userInfo);
        //}

        //[HttpPost]
        //public IActionResult Create(AccountCreateModel model)
        //{
        //    //_context.Accounts.Add(
        //    //    new Account
        //    //    {
        //    //        UserId = model.UserId,
        //    //        Balance = model.Balance,
        //    //        AccountNumber = model.AccountNumber
        //    //    });
        //    //_context.SaveChanges();

        //    _accountRepository.Create(_accountMapper.Map(model));

        //    return RedirectToAction("Index", "Home");
        //}



        //     Do not need with Unit Of Work
        // creating with IRepository generic interface
        //private readonly IRepository<User> _userRepository;
        //private readonly IRepository<Account> _accountRepository;

        //public AccountController(IRepository<User> userRepository, IRepository<Account> accountRepository)
        //{
        //    _userRepository = userRepository;
        //    _accountRepository = accountRepository;
        //}


        // IUow instance
        private readonly IUow _uow;

        // DI
        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        // Create new Account on existing User. GetRepository brings us User information with id from db
        public IActionResult Create(int id)
        {
            //User userInfo = _userRepository.GetById(id);
            User userInfo = _uow.GetRepository<User>().GetById(id);
            
            // this users return model. use these info and create Account
            return View(new UserModel{
                Id = userInfo.Id,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName
            });
        }

        [HttpPost]
        // post method for Create method. takes info from view
        public IActionResult Create(AccountCreateModel model)
        {
            // _accountRepository.Create(new Account{ UserId = model.UserId, Balance = model.Balance, AccountNumber = model.AccountNumber});
            _uow.GetRepository<Account>().Create(new Account{ UserId = model.UserId, Balance = model.Balance, AccountNumber = model.AccountNumber});
            _uow.SaveChanges();

            // return Home/Index.cshtml
            return RedirectToAction("Index", "Home");
        }

        // get Account by UserId
        public IActionResult GetByUserId(int userId)
        {
            // open query during program running
            // IQueryable<Account> query = _accountRepository.GetQueryable();
            IQueryable<Account> query = _uow.GetRepository<Account>().GetQueryable();

            // this query brings information from db then execute
            List<Account> accounts = query.Where(x => x.UserId == userId).ToList();

            // get Uset info
            // User user = _userRepository.GetById(userId);
            User user = _uow.GetRepository<User>().GetById(userId);

            List<AccountModel> list = new List<AccountModel>();

            // send info to view with ViewBag
            ViewBag.FullName = user.FirstName + " " + user.LastName;

            // list of Accounts User has
            foreach (Account account in accounts)
            {
                list.Add(new()
                {
                    Id = account.Id,
                    Balance = account.Balance,
                    UserId = account.UserId
                });
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            // get account info
            // IQueryable<Account> query = _accountRepository.GetQueryable();
            IQueryable<Account> query = _uow.GetRepository<Account>().GetQueryable();

            //  accounts except current(now using) account
            List<Account> accounts = query.Where(x=> x.Id != accountId).ToList();

            // send accountId to view
            ViewBag.SenderId = accountId;

            // list of accounts. casting account list to accountModel list
            // for save entity records
            List<AccountModel> list = new List<AccountModel>();
            foreach (Account account in accounts)
            {
                list.Add(new()
                {
                    Id = account.Id,
                    UserId = account.UserId,
                    Balance = account.Balance,
                    AccountNumber = account.AccountNumber
                });
            }

            // prune list for specific Id and AccountNumber
            return View(new SelectList(list,"Id","AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            // Unit Of Work(Uow) DesignPattern

            // var sender = _accountRepository.GetById(model.SenderId);
            var sender = _uow.GetRepository<Account>().GetById(model.SenderId);

            sender.Balance -= model.Amount;
            // _accountRepository.Update(sender);
            _uow.GetRepository<Account>().Update(sender);

            // var receiver = _accountRepository.GetById(model.ReceiverId);
            var receiver = _uow.GetRepository<Account>().GetById(model.ReceiverId);
            receiver.Balance += model.Amount;

            // _accountRepository.Update(receiver);
            _uow.GetRepository<Account>().Update(receiver);

            _uow.SaveChanges();

            return RedirectToAction("Index","Home");
        }
    }
}
