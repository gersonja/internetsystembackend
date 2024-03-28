using InternetSystem.DBModels;
using InternetSystem.Models;

namespace InternetSystem.Repository
{
    public class TurnRepository
    {
        private readonly InternetsysContext _Context;
        public TurnRepository(InternetsysContext ctx)
        {
            _Context = ctx;
        }

        public List<Turn?> GetTurns()
        {
            var listTurn = _Context.Turns.ToList();
            return listTurn;
        }
        public Turn? GetTurn(int id)
        {
            var turnFind = _Context.Turns.Where(x => x.Turnid == id).FirstOrDefault();

            return turnFind;
        }

        public TurnModelResponse CreateTurn(CreationTurnModelReq model)
        {
            var lastTurn = _Context.Turns.Where
                (t => t.Description.StartsWith(model.AttentionTypePK))
                .OrderByDescending(t => t.Description).FirstOrDefault();
            string newDescription;
            int nextNumber;
            if (lastTurn != null)
            {
                var numericPart = lastTurn.Description.Substring(3);
                nextNumber = int.Parse(numericPart) + 1;
                newDescription = $"{model.AttentionTypePK}{nextNumber:D4}";
            } else
            {
                nextNumber = 1;
                newDescription = $"{model.AttentionTypePK}{nextNumber:D4}";
            }

            var createdTurn = new Turn()
            {
                CashCashid = _Context.Cashes.Where(c => c.Cashdescription == "Waiting cash").FirstOrDefault().Cashid,
                Date = DateTime.Now,
                Description = newDescription,
            };

            try
            {
                _Context.Turns.Add(createdTurn);
                _Context.SaveChanges();

                var createdAttention = new Attention()
                {
                    TurnTurnid = createdTurn.Turnid,
                    ClientClientid = model.ClientId,
                    AttentiontypeAttentiontypeid = model.AttentionTypePK,
                    AttentionstatusStatusid = 1
                };

                _Context.Attentions.Add(createdAttention);
                _Context.SaveChanges();

                return new TurnModelResponse()
                {
                    description = createdTurn.Description
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
