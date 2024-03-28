using InternetSystem.DBModels;

namespace InternetSystem.Repository
{
    public class AttentionTypeRepository
    {

        private InternetsysContext _Context;
        public AttentionTypeRepository(InternetsysContext ctx)
        {
            _Context = ctx;
        }
        public List<Attentiontype> GetAttentionsType()
        {
            var attentionsTypeFound = _Context.Attentiontypes.ToList();
            return attentionsTypeFound;
        }
    }
}
