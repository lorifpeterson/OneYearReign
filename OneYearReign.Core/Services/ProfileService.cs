using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OneYearReign.Core.Interfaces;
using OneYearReign.Core.Models;

namespace OneYearReign.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;
        private readonly IMemberRepository _memberRepository;

        public ProfileService(IProfileRepository repository, IMemberRepository memberRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
        }

        public Profile GetBandProfile()
        {
            return _repository.GetProfile();
        }

        public IEnumerable<Member> GetMembers()
        {
            return _memberRepository.All();
        }
    }
}
