
public class CodingStandard 
{
    // ------------ ORDERING ----------------
    
        // Constructor if any
        // Variables
            // Editor inspector variables such as Text text; 
            // fields
            // properties
            // events

        // public methods
        // Monobehaviour methods
        // private (helper) methods

        private int _health = 100;

        public int Health {
            get => _health;
            set => _health = value;
        }


    // ------------ CONVENTIONS ----------------
    // only use "this" when necessary. we use _ for private fields.
    
    
    
    // private methods should be explicit for clarity. e.g:
    private void PrivateMethods() {
        
        // Always use the property when accessing class fields. 
        Health = 4; 
    }
}
