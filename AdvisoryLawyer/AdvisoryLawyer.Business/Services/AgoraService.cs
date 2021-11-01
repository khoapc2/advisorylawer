using AdvisoryLawyer.Business.IServices;
using AdvisoryLawyer.Business.Requests.AgoraRequest;
using AdvisoryLawyer.Business.Utilities.Media;
using AdvisoryLawyer.Business.ViewModel;
using AdvisoryLawyer.Data.IRepositories;
using AdvisoryLawyer.Data.Models;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.Services
{
    public class AgoraService : IAgoraService
    {
        private IConfiguration _config;
        private readonly IGenericRepository<AgoraChannel> _genericRepository;
        private readonly IMapper _mapper;

        public AgoraService(IConfiguration config, IGenericRepository<AgoraChannel> genericRepository, IMapper mapper)
        {
            _config = config;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public AgoraChannelModel GetChannel(AgoraRequest request)
        {
            string channel = request.Channel;
            string _uid = request.Uid;
            uint _ts = 1111111;
            uint _salt = 1;
            uint _expiredTs = 1446455471;

            AccessToken token = new AccessToken(_config["Agora:AppID"], _config["Agora:AppCertificate"], channel, _uid, _ts, _salt);
            token.message.ts = _ts;
            token.message.salt = _salt;
            token.addPrivilege(Privileges.kJoinChannel, _expiredTs);
            token.addPrivilege(Privileges.kPublishVideoStream, _expiredTs);
            token.addPrivilege(Privileges.kPublishAudioStream, _expiredTs);
            token.addPrivilege(Privileges.kPublishDataStream, _expiredTs);
            token.addPrivilege(Privileges.kRtmLogin, _expiredTs);
            string tokenString = token.build();

            return new AgoraChannelModel {Token = tokenString, Channel = channel };
        }

        public async Task InsertChannel(string channel, int bookingId)
        {
            var agoraChannel = new AgoraChannel {
                BookingId = bookingId,
                ChannelName = channel,
                Status = 1
            };

            await _genericRepository.InsertAsync(agoraChannel);
            await _genericRepository.SaveAsync();
        }

        public async Task<AgoraChannelReponse> GetChannalByBookingID(int id)
        {
            var channel = await _genericRepository.FindAsync(c => c.BookingId == id && c.Status == 1);
            return _mapper.Map<AgoraChannelReponse>(channel);
        }
    }
}
