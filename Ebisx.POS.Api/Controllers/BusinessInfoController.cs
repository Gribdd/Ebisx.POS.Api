using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ebisx.POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessInfoController : ControllerBase
    {
        private readonly IBusinessInfoService _businessInfoService;

        public BusinessInfoController(IBusinessInfoService businessInfoService)
        {
            _businessInfoService = businessInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessInfo>>> GetAllBusinessInfo()
        {
            var businessInfoList = await _businessInfoService.GetAllBusinessInfoAsync();
            return Ok(businessInfoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessInfo>> GetBusinessInfoById(int id)
        {
            var businessInfo = await _businessInfoService.GetBusinessInfoByIdAsync(id);
            if (businessInfo == null)
            {
                return NotFound();
            }
            return Ok(businessInfo);
        }

        [HttpPost]
        public async Task<ActionResult<BusinessInfo>> CreateBusinessInfo(BusinessInfo businessInfo)
        {
            var createdBusinessInfo = await _businessInfoService.CreateBusinessInfoAsync(businessInfo);
            return CreatedAtAction(nameof(GetBusinessInfoById), new { id = createdBusinessInfo.Id }, createdBusinessInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusinessInfo(int id, BusinessInfo businessInfo)
        {
            var updated = await _businessInfoService.UpdateBusinessInfoAsync(id, businessInfo);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessInfo(int id)
        {
            var deleted = await _businessInfoService.DeleteBusinessInfoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class MachineInfoController : ControllerBase
    {
        private readonly IMachineInfoService _machineInfoService;

        public MachineInfoController(IMachineInfoService machineInfoService)
        {
            _machineInfoService = machineInfoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineInfo>>> GetAllMachineInfo()
        {
            var machineInfoList = await _machineInfoService.GetAllMachineInfoAsync();
            return Ok(machineInfoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MachineInfo>> GetMachineInfoById(int id)
        {
            var machineInfo = await _machineInfoService.GetMachineInfoByIdAsync(id);
            if (machineInfo == null)
            {
                return NotFound();
            }
            return Ok(machineInfo);
        }

        [HttpPost]
        public async Task<ActionResult<MachineInfo>> CreateMachineInfo(MachineInfo machineInfo)
        {
            var createdMachineInfo = await _machineInfoService.CreateMachineInfoAsync(machineInfo);
            return CreatedAtAction(nameof(GetMachineInfoById), new { id = createdMachineInfo.Id }, createdMachineInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMachineInfo(int id, MachineInfo machineInfo)
        {
            var updated = await _machineInfoService.UpdateMachineInfoAsync(id, machineInfo);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachineInfo(int id)
        {
            var deleted = await _machineInfoService.DeleteMachineInfoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentType>>> GetAllPaymentTypes()
        {
            var paymentTypes = await _paymentTypeService.GetAllPaymentTypesAsync();
            return Ok(paymentTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentType>> GetPaymentTypeById(int id)
        {
            var paymentType = await _paymentTypeService.GetPaymentTypeByIdAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }
            return Ok(paymentType);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentType>> CreatePaymentType(PaymentType paymentType)
        {
            var createdPaymentType = await _paymentTypeService.CreatePaymentTypeAsync(paymentType);
            return CreatedAtAction(nameof(GetPaymentTypeById), new { id = createdPaymentType.Id }, createdPaymentType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentType(int id, PaymentType paymentType)
        {
            var updated = await _paymentTypeService.UpdatePaymentTypeAsync(id, paymentType);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentType(int id)
        {
            var deleted = await _paymentTypeService.DeletePaymentTypeAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> CreatePayment(Payment payment)
        {
            var createdPayment = await _paymentService.CreatePaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = createdPayment.Id }, createdPayment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, Payment payment)
        {
            var updated = await _paymentService.UpdatePaymentAsync(id, payment);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var deleted = await _paymentService.DeletePaymentAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

    // Similarly, you would create controllers for NonCashPaymentMethodController, CustomerController,
    // DiscountController, and DiscountTypeController.

    // Below is an example of the `NonCashPaymentMethodController`.

    [Route("api/[controller]")]
    [ApiController]
    public class NonCashPaymentMethodController : ControllerBase
    {
        private readonly INonCashPaymentMethodService _nonCashPaymentMethodService;

        public NonCashPaymentMethodController(INonCashPaymentMethodService nonCashPaymentMethodService)
        {
            _nonCashPaymentMethodService = nonCashPaymentMethodService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonCashPaymentMethod>>> GetAllNonCashPaymentMethods()
        {
            var nonCashPaymentMethods = await _nonCashPaymentMethodService.GetAllNonCashPaymentMethodsAsync();
            return Ok(nonCashPaymentMethods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NonCashPaymentMethod>> GetNonCashPaymentMethodById(int id)
        {
            var nonCashPaymentMethod = await _nonCashPaymentMethodService.GetNonCashPaymentMethodByIdAsync(id);
            if (nonCashPaymentMethod == null)
            {
                return NotFound();
            }
            return Ok(nonCashPaymentMethod);
        }

        [HttpPost]
        public async Task<ActionResult<NonCashPaymentMethod>> CreateNonCashPaymentMethod(NonCashPaymentMethod nonCashPaymentMethod)
        {
            var createdNonCashPaymentMethod = await _nonCashPaymentMethodService.CreateNonCashPaymentMethodAsync(nonCashPaymentMethod);
            return CreatedAtAction(nameof(GetNonCashPaymentMethodById), new { id = createdNonCashPaymentMethod.Id }, createdNonCashPaymentMethod);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNonCashPaymentMethod(int id, NonCashPaymentMethod nonCashPaymentMethod)
        {
            var updated = await _nonCashPaymentMethodService.UpdateNonCashPaymentMethodAsync(id, nonCashPaymentMethod);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNonCashPaymentMethod(int id)
        {
            var deleted = await _nonCashPaymentMethodService.DeleteNonCashPaymentMethodAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            var createdCustomer = await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            var updated = await _customerService.UpdateCustomerAsync(id, customer);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleted = await _customerService.DeleteCustomerAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
