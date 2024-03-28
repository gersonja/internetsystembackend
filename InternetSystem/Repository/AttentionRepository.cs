using InternetSystem.DBModels;
using InternetSystem.Models;

namespace InternetSystem.Repository
{
    public class AttentionRepository
    {
        private InternetsysContext _Context;
        public AttentionRepository(InternetsysContext ctx)
        {
            _Context = ctx;
        }
        public List<Attention> GetAttentions()
        {
            var attentionsFound = _Context.Attentions.ToList();
            return attentionsFound;
        }

        public Attention? GetAttention(int id)
        {
            var attentionFound = _Context.Attentions.Where(x => x.Attentionid == id).FirstOrDefault();

            return attentionFound;
        }

        public Attention? CreateAttention(AttentionModelReq attention)
        {
            var AttentionTemplate = new Attention()
            {
                TurnTurnid = attention.Turnid,
                ClientClientid = attention.Clientid,
                AttentiontypeAttentiontypeid = attention.AttentionTypeid,
                AttentionstatusStatusid = attention.AttentionStatusid,
            };

            try
            {
                _Context.Attentions.Add(AttentionTemplate);
                _Context.SaveChanges();
                return AttentionTemplate;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string? DeleteAttentionById(int id)
        {
            Attention attention = new Attention() { Attentionid = id };
            try
            {
                _Context.Attach(attention);
                _Context.Remove(attention);
                _Context.SaveChanges();
                return "Removed attention succesfully";
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Attention? UpdateAttention(int id, AttentionModelReq AttentionData)
        {
            try
            {
                var attentionFoundById = _Context.Attentions.First(u => u.Attentionid == id);
                attentionFoundById.AttentionstatusStatusid = AttentionData.AttentionStatusid;
                attentionFoundById.AttentiontypeAttentiontypeid = AttentionData.AttentionTypeid;
                attentionFoundById.TurnTurnid = AttentionData.Turnid;
                _Context.SaveChanges();
                return attentionFoundById;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
