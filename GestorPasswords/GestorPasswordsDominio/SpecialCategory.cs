namespace DataManagerDomain
{
    public class SpecialCategory : Category
    {
        public SpecialCategory()
        {
            Name = "Passwords Shared With me";
        }

        public override bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            AddUserPasswordPairToCollection(aUserPasswordPair);
            return true;
        }

        public override bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            RemoveUserPasswordPairFromCollection(aUserPasswordPair);
            return true;
        }
    }
}
