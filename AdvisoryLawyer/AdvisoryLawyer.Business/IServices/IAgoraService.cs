using AdvisoryLawyer.Business.Requests.AgoraRequest;
using AdvisoryLawyer.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisoryLawyer.Business.IServices
{
    public interface IAgoraService
    {
        public AgoraChannelModel GetChannel(AgoraRequest request);
        public Task InsertChannel(string channel, int bookingId);
        public Task<AgoraChannelReponse> GetChannalByBookingID(int id);
    }
}
