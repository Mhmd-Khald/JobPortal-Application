using AutoMapper;
using Job.Core.Entities;
using Job.Core.Repositories;
using Job.Repository.Data;
using Job.Repository.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Apis.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Apis.Controllers
{

    public class OfferController : BaseApiController
    {
        private readonly StoreDbContext _context;
        private readonly IGenericRepositories<Offers> _offerRepo;
        private readonly IGenericRepositories<Jobs> _jobRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public OfferController(StoreDbContext context,
            IGenericRepositories<Offers> offerRepo,
            UserManager<AppUser> userManager,
            IGenericRepositories<Jobs> JobRepo,
            IMapper mapper
            )
        {
            _context = context;
            _offerRepo = offerRepo;
            _userManager = userManager;
            _jobRepo = JobRepo;
            _mapper = mapper;
        }

      
        [HttpPost("SendofferToUser/{id}")]
        [Authorize(Roles = "company")]
        public async Task<ActionResult> SendOffer(  string id , [FromBody] OfferCompany offer)
        {
            // Get the currently authenticated user (the sender)
            var email = User.FindFirstValue(ClaimTypes.Email);
            var sender = await _userManager.FindByEmailAsync(email);
          

            // Find the recipient user by ID and check if they have the 'User' role
            var recipient = await _userManager.FindByIdAsync(id);
            if (recipient == null || !await _userManager.IsInRoleAsync(recipient, "User"))
            {
                return BadRequest("Invalid recipient user ID");
            }
            var check = _context.OfferCompany.Where(a => a.SenderId == sender.Id && a.RecipientId == recipient.Id).ToList();

            if (check.Count < 1)
            {
                // Create a new offer and set its properties
                var newOffer = new OfferCompany
                {
                    Message = offer.Message,
                    OfferdDate = DateTime.Now,
                    SenderId = sender.Id,
                    RecipientId = recipient.Id,
                };
                // Save the new offer to the database
                _context.OfferCompany.Add(newOffer);
                await _context.SaveChangesAsync();
                // Return a 201 Created response with the new offer entity
                return Ok("OfferCreatedSuccecfully");
            }
            else
                return BadRequest("You Send Offer Before");          
        }

        [HttpDelete("DeleteOffer/{id}")]
        [Authorize (Roles ="company")]
        public async Task<ActionResult> DeleteOffer(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var offer = await _context.OfferCompany.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }
            else if (offer.SenderId != user.Id)
            {
                return Unauthorized();
            }
            else
            {
                _context.OfferCompany.Remove(offer);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpGet("GetReceivedOffers")]
        [Authorize (Roles ="User")]
        public async Task<ActionResult<IEnumerable<ReturnOfferCompany>>> GetReceivedOffers()
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return(NotFound());
                }
                var applicants = await _context.OfferCompany
                   .Where(o => o.RecipientId == user.Id)
                   .Select(o => new ReturnOfferCompany
                   {
                    
                       Message = o.Message,
                       OfferdDate = o.OfferdDate,
                       userName = o.Sender.UserName,
                       sender = o.Sender.DisplayName,
                       Email = o.Sender.Email,
                       SendrId = o.Sender.Id,
                       PictureUrl = o.Sender.PictureUrl
                   })
                   .ToListAsync();
                return Ok(applicants);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }

        }
        [HttpGet("GetSentOffers")]
        [Authorize(Roles = "company")]
        public async Task<ActionResult<IEnumerable<ReturnSendOffer>>> GetSentOffers()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return (NotFound());
            }
            var sentOffers = await _context.OfferCompany
                .Where(o => o.SenderId == user.Id)
                .Select(o => new ReturnSendOffer
                {
                    OfferId= o.Id,
                    Message = o.Message,
                    OfferdDate = o.OfferdDate,
                    Reciver = o.Recipient.DisplayName,
                    Bio = o.Recipient.Bio,
                    PictureUrl = o.Recipient.PictureUrl,
                    ReciverId=o.Recipient.Id
                })
                .ToListAsync();

            return Ok(sentOffers);
        }





    }
}
    

