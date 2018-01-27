using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TheTravelingSalesperson
{
    /// <summary>
    /// MVC Controller class
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private bool _usingApplication;
        private Salesperson _salesperson;
        private ConsoleView _consoleview;

        //
        // declare ConsoleView and Salesperson objects for the Controller to use
        // Note: There is no need for a Salesperson or ConsoleView property given only the Controller 
        //       will access the ConsoleView object and will pass the Salesperson object to the ConsoleView.
        //


        #endregion

        #region PROPERTIES


        #endregion
        
        #region CONSTRUCTORS

        public Controller()
        {
            InitializeController();

            //
            // instantiate a Salesperson object
            //
            _salesperson = new Salesperson();

            //
            // instantiate a ConsoleView object
            //
            _consoleview = new ConsoleView();

            //
            // begins running the application UI
            //
            ManageApplicationLoop();
        }

        #endregion
        
        #region METHODS

        /// <summary>
        /// initialize the controller 
        /// </summary>
        private void InitializeController()
        {
            _usingApplication = true;
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageApplicationLoop()
        {
            MenuOption userMenuchoice;

            _consoleview.DisplayWelcomeScreen();

            //
            // setup initial salesperson account
            //
            _salesperson = _consoleview.DisplaySetupAccount();

            //
            // applicaito loop
            //
            while (_usingApplication)
            {
                //
                // get a menu choice form the user
                //
                userMenuchoice = _consoleview.DisplayGetUserMenuChoice();

                //
                // choose an aciton based on the user menu choice
                //
                switch (userMenuchoice)
                {
                    case MenuOption.None:
                        break;

                    case MenuOption.Travel:
                        Travel();
                        break;

                    case MenuOption.DisplayCities:
                        DisplayCities();
                        break;

                    case MenuOption.DisplayAccountInfo:
                        DisplayAccountInfo();
                        break;

                    case MenuOption.Exit:
                        _usingApplication = false;
                        _consoleview.DisplayClosingScreen();
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// add the next city location to the list of cities
        /// </summary>
        private void Travel()
        {
            string nextCity = _consoleview.DisplayGetNextCity();

            //
            // add next city to list only if the string isn't empty
            //
            if (nextCity != "")
            {
                _salesperson.CitiesVisited.Add(nextCity);
            }            
        }

        /// <summary>
        /// display all cities traveled to
        /// </summary>
        private void DisplayCities()
        {
            _consoleview.DisplayCitiesTraveled(_salesperson);
        }

        /// <summary>
        /// display account information
        /// </summary>
        private void DisplayAccountInfo()
        {
            _consoleview.DisplayAccountInfo(_salesperson);     
        }

        #endregion
    }
}
