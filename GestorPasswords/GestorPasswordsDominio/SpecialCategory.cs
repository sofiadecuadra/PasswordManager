namespace GestorPasswordsDominio
{
    public class SpecialCategory : Category
    {
        public SpecialCategory()
        {
            Name = "Shared Passwords";
        }

        public override bool AddUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            AddUserPasswordPairToHashTable(aUserPasswordPair);
            
            return true;
        }

        public override bool RemoveUserPasswordPair(UserPasswordPair aUserPasswordPair)
        {
            if (!this.UserPasswordPairAlredyExistsInCategory(aUserPasswordPair.Username, aUserPasswordPair.Site))
            {
                string message = $"The user-password pair ({aUserPasswordPair.Username}-{aUserPasswordPair.Site}) does not exist in {this.Name}";
                throw new ExceptionUserPasswordPairDoesNotExist(message);
            }

            RemoveUserPasswordPairFromCollection(aUserPasswordPair);
            return true;
        }
    }
}
