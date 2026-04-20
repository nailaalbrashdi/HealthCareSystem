

using System.Xml.Linq;

namespace HealthCareSystem
{
    internal class Program
    {

        // System Storage

        static List<string> patientNames = new List<string>();
        static List<string> patientIDs = new List<string>();
        static List<string> diagnoses = new List<string>();
        static List<bool> admitted = new List<bool>();
        static List<string> assignedDoctors = new List<string>();
        static List<string> departments = new List<string>();
        static List<int> visitCount = new List<int>();
        static List<double> billingAmount = new List<double>();

        static List<DateTime> lastVisitDate = new List<DateTime>();
        static List<DateTime> lastDischargeDate = new List<DateTime>();
        static List<int> daysInHospital = new List<int>();
        static List<string> bloodType = new List<string>();

        static List<string> doctorNames = new List<string>();
        static List<int> doctorAvailableSlots = new List<int>();
        static List<int> doctorVisitCount = new List<int>();
        static bool exit = false;

        static public void seedData()
        {


            //Patient 1

            patientNames.Add("Ali Hassan");
            patientIDs.Add("P001");
            diagnoses.Add("Flu");
            admitted.Add(false);
            assignedDoctors.Add("");
            departments.Add("General");
            visitCount.Add(2);
            billingAmount.Add(0);
            lastVisitDate.Add(DateTime.Parse("2025-01-10"));
            lastDischargeDate.Add(DateTime.Parse("2025-01-15"));
            daysInHospital.Add(12);
            bloodType.Add("A+");

            //Patient 2

            patientNames.Add("Sara Ahmed");
            patientIDs.Add("P002");
            diagnoses.Add("Fracture");
            admitted.Add(true);
            assignedDoctors.Add("Noor");
            departments.Add("Orthopedics");
            visitCount.Add(4);
            billingAmount.Add(0);
            lastVisitDate.Add(DateTime.Parse("2025-03-02"));
            lastDischargeDate.Add(DateTime.MinValue);
            daysInHospital.Add(8);
            bloodType.Add("O-");

            //Patient 3

            patientNames.Add("Omar Khalid");
            patientIDs.Add("P003");
            diagnoses.Add("Diabetes");
            admitted.Add(false);
            assignedDoctors.Add("");
            departments.Add("Cardiology");
            visitCount.Add(1);
            billingAmount.Add(0);
            lastVisitDate.Add(DateTime.Parse("2024-12-20"));
            lastDischargeDate.Add(DateTime.Parse("2024-12-28"));
            daysInHospital.Add(5);
            bloodType.Add("B+");

            //Doctor 1

            doctorNames.Add("Noor");
            doctorAvailableSlots.Add(5);
            doctorVisitCount.Add(0);

            //Doctor 2

            doctorNames.Add("Salem");
            doctorAvailableSlots.Add(3);
            doctorVisitCount.Add(0);

            //Doctor 3

            doctorNames.Add("Hana");
            doctorAvailableSlots.Add(8);
            doctorVisitCount.Add(0);


        }

        static public void displayMenu()
        {
            Console.WriteLine("Healthcare Management System");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1. Register New Patient");
            Console.WriteLine("2. Admit Patient");
            Console.WriteLine("3. Discharge Patient");
            Console.WriteLine("4. Search Patient");
            Console.WriteLine("5. List All Admitted Patients");
            Console.WriteLine("6. Transfer Patient to Another Doctor");
            Console.WriteLine("7. View Most Visited Patients");
            Console.WriteLine("8. Search Patients by Department");
            Console.WriteLine("9. Billing Report");
            Console.WriteLine("10. Add Doctor");
            Console.WriteLine("11. Doctor Salary Report");
            Console.WriteLine("12. Exit");
        }

        static public string registerPatient()
        {
            Console.WriteLine("Enter patient name: ");
            string name = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the diagnose: ");
            string diagnose = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the blood type: ");
            string blood = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter the department: ");
            string department = Console.ReadLine().ToLower();

            
            patientNames.Add(name);
            diagnoses.Add(diagnose);
            departments.Add(department);
            bloodType.Add(blood);
            admitted.Add(false);
            assignedDoctors.Add("");
            visitCount.Add(0);
            billingAmount.Add(0);
            lastDischargeDate.Add(DateTime.MinValue);
            lastVisitDate.Add(DateTime.MinValue);
            daysInHospital.Add(0);
            
            string newID = "P" + (patientIDs.Count + 1).ToString("D3");
            patientIDs.Add(newID);   
            Console.WriteLine("Patient registered successfully with patient ID: " + newID);

            return newID;

        }
        static public int searchPatient(string searchInput)
        {
            //int pateintFound = -1;


            //string normalizedInput = searchInput.Trim().ToLower();

            //for (int i = 0; i < lastIndex; i++)
            //{

            //    if (patientNames[i].ToLower().Trim() == normalizedInput ||
            //        patientIDs[i].ToLower().Trim() == normalizedInput)
            //    {
            //        pateintFound = i;
            //        break;
            //    }
            //}

            //return pateintFound;

            return patientNames.IndexOf(searchInput.ToLower());

        }

        static public void printPatientInfo(int index)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Name:           " + patientNames[index]);
            Console.WriteLine("ID:             " + patientIDs[index].ToUpper());
            Console.WriteLine("Diagnosis:      " + diagnoses[index] + " (" + diagnoses[index].Length + " characters)");
            Console.WriteLine("Blood Type:     " + bloodType[index]);
            Console.WriteLine("Department:     " + departments[index]);
            Console.WriteLine("Admitted:       " + admitted[index]);
            Console.WriteLine("Total Visits:   " + visitCount[index]);
            Console.WriteLine("Total Billing: " + Convert.ToString(Math.Round(billingAmount[index], 2)) + " OMR");
            if (admitted[index] == false)
            {

                Console.WriteLine("patient not currently admitted.");
            }
            else
            {

                Console.WriteLine("Doctor:" + assignedDoctors[index]);
            }
            if (lastVisitDate[index] != new DateTime())
            {
                Console.WriteLine("Last Visit Date: " + lastVisitDate[index].ToShortDateString());
            }
            if (lastDischargeDate[index] != new DateTime())
            {
                Console.WriteLine("Last Discharge Date: " + lastDischargeDate[index].ToShortDateString());
            }
            Console.WriteLine("Total days in hospital :" + daysInHospital[index]);
        }

        static public void AdmitPatient(int admitIndex)
        {
            if (admitted[admitIndex])
            {
                Console.WriteLine("Patient is already admitted under " + assignedDoctors[admitIndex]);
            }
            else
            {
                Console.Write("Doctor Name: ");
                string inputDoctor = (Console.ReadLine() ?? "").Trim(); 

                int doctorIndex = -1;

                
                for (int i = 0; i < patientNames.Count ; i++)
                {
                    if (!string.IsNullOrEmpty(doctorNames[i]) &&
                        doctorNames[i].Equals(inputDoctor, StringComparison.OrdinalIgnoreCase))
                    {
                        doctorIndex = i;
                        break;
                    }
                }

                
                if (doctorIndex == -1)
                {
                    Console.WriteLine("Doctor not found in system.");
                    return;
                }

                
                if (doctorAvailableSlots[doctorIndex] <= 0)
                {
                    Console.WriteLine("Doctor has no available slots.");
                    return;
                }

                
                assignedDoctors[admitIndex] = doctorNames[doctorIndex];

                
                doctorAvailableSlots[doctorIndex]--;      // decrement slot
                doctorVisitCount[doctorIndex]++;          // increment visits

                
                Console.WriteLine("Remaining slots for " + doctorNames[doctorIndex] + ": " + doctorAvailableSlots[doctorIndex]);

                DateTime admissionDate = DateTime.Now;
                lastVisitDate[admitIndex] = admissionDate;

                Console.WriteLine("Admission Date: " + admissionDate.ToString("yyyy-MM-dd HH:mm"));

                admitted[admitIndex] = true;
                visitCount[admitIndex]++;

                Console.WriteLine("Patient admitted successfully and assigned to " + assignedDoctors[admitIndex]);

                if (visitCount[admitIndex] > 1)
                {
                    Console.WriteLine("This patient has been admitted " + visitCount[admitIndex] + " times");
                }
                else
                {
                    Console.WriteLine("This patient is being admitted for the first time");
                }
            }
        }

        static public void DischargePatient(int index)
        {
            if (!admitted[index])
            {
                Console.WriteLine("This patient is not currently admitted");
                return;
            }

            double visitCharges = 0;

            Console.Write("Was there a consultation fee? (yes/no): ");
            string hasFee = (Console.ReadLine() ?? "").Trim().ToLower();

            if (hasFee == "yes")
            {
                Console.Write("Enter consultation fee amount: ");
                double fee;

                if (double.TryParse(Console.ReadLine() ?? string.Empty, out fee)) 
                {
                    if (fee > 0)
                    {
                        fee = Math.Round(fee, 2);
                        billingAmount[index] = Math.Round(billingAmount[index] + fee, 2);
                        visitCharges += fee;
                    }
                    else
                    {
                        Console.WriteLine("Fee must be positive");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a number.");
                }
            }

            Console.Write("Any medication charges? (yes/no): ");
            string hasMeds = Console.ReadLine() ?? string.Empty.ToLower();

            if (hasMeds == "yes")
            {
                
                Console.Write("Enter medication charges amount: ");
                double meds;

                if (double.TryParse(Console.ReadLine() ?? string.Empty, out meds)) 
                {
                    if (meds > 0)
                    {
                        meds = Math.Round(meds, 2);
                        billingAmount[index] += meds;
                        visitCharges += meds;
                    }
                    else
                    {
                        Console.WriteLine("Charges must be positive");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a number.");
                }
            }

            Console.WriteLine("Total charges added this visit: " + visitCharges + " OMR");

            
            string doctorName = assignedDoctors[index];

            
            if (!string.IsNullOrEmpty(doctorName))
            {
                for (int i = 0; i < patientNames.Count ; i++)
                {
                    if (doctorNames[i] == doctorName)
                    {
                        doctorAvailableSlots[i]++; 
                        break;
                    }
                }
            }

            
            assignedDoctors[index] = "";

            admitted[index] = false;

            Console.Write("Enter Discharge Date (yyyy-MM-dd): ");
            string inputDate = Console.ReadLine() ?? string.Empty;

            DateTime dischargeDate;

            if (DateTime.TryParse(inputDate, out dischargeDate)) 
            {
                lastDischargeDate[index] = dischargeDate;
            }
            else
            {
                Console.WriteLine("Invalid date. Discharge date not recorded.");
            }

            Console.Write("Enter days spent in hospital: ");
            int days;

            if (int.TryParse(Console.ReadLine() ?? string.Empty, out days)) 
            {
                daysInHospital[index] += days; 
            }
            else
            {
                Console.WriteLine("Invalid number. Days not updated.");
            }

            Console.WriteLine("Patient discharged successfully!");
        }

        static public void ShowAdmittedPatients()
        {
            Console.WriteLine("Currently Admitted Patients:");
            Console.Write("Filter by name keyword (press Enter to skip): ");
            string nameFilter = (Console.ReadLine() ?? "").ToLower();

            Console.WriteLine("----------------------------------------");

            bool hasAdmitted = false;
            int admittedCount = 0; 

            for (int i = 0; i < patientNames.Count ; i++)
            {
                if (admitted[i])
                {
                    if (!string.IsNullOrEmpty(nameFilter) &&
                        !patientNames[i].ToLower().Contains(nameFilter))
                    {
                        continue;
                    }

                    Console.WriteLine(
                        "Name: " + patientNames[i] +
                        " | ID: " + patientIDs[i] +
                        " | Diagnosis: " + diagnoses[i] +
                        " | Department: " + departments[i] +
                        " | Doctor: " + assignedDoctors[i] +
                        " | Admitted Since: " + lastVisitDate[i].ToString("yyyy-MM-dd")
                    );

                    hasAdmitted = true;
                    admittedCount++;

                    if (visitCount[i] > 1)
                        Console.WriteLine("This patient has been admitted " + visitCount[i] + " times");
                    else
                        Console.WriteLine("This patient is being admitted for the first time"); 
                }
            }

            if (!hasAdmitted)
            {
                Console.WriteLine("No admitted patients found.");
            }
            else
            {
                
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Total admitted patients: " + admittedCount);
            }
        }
        static public void TransferPatient()
        {
            Console.Write("Enter current doctor name: ");
            string currentDoctor = Console.ReadLine() ?? string.Empty.Trim().Replace("Dr ", "Dr.");

            Console.Write("Enter new doctor name: ");
            string newDoctor = Console.ReadLine() ?? string.Empty.Trim().Replace("Dr ", "Dr.");

            
            if (currentDoctor == newDoctor)
            {
                Console.WriteLine("Error: current doctor and new doctor cannot be the same.");
                return;
            }

            bool doctorFound = false;

            for (int i = 0; i < patientNames.Count ; i++)
            {
                if (assignedDoctors[i] == currentDoctor && admitted[i] == true)
                {
                    doctorFound = true;

                    
                    assignedDoctors[i] = newDoctor;

                    Console.WriteLine(
                        "Patient '" + patientNames[i] +
                        "' has been transferred from " + currentDoctor +
                        " to " + newDoctor
                    );

                    Console.WriteLine("Patient last admitted on: " + lastVisitDate[i]);

                    break;
                }
            }

            if (!doctorFound)
            {
                Console.WriteLine("No admitted patients found under this doctor");
            }
        }

        static public void ViewMostVisitedPatients()
        {
            Console.WriteLine("Most Visited Patients (by visit count):");
            Console.WriteLine("----------------------------------------");

            int[] tempVisits = new int[100];

            for (int i = 0; i < patientNames.Count; i++)
            {
                tempVisits[i] = visitCount[i];
            }

            for (int pass = 0; pass < patientNames.Count; pass++)
            {
                int maxIndex = 0;

                for (int i = 0; i < patientNames.Count ; i++)
                {
                    if (tempVisits[i] > tempVisits[maxIndex])
                    {
                        maxIndex = i;
                    }
                }

                Console.WriteLine("ID: " + patientIDs[maxIndex] + " | Name: " + patientNames[maxIndex] + " | Visits: " + tempVisits[maxIndex]);

                tempVisits[maxIndex] = -1;
            }
        }

        static public void SearchByDepartment()
        {
            Console.Write("Enter department name: ");
            string searchDept = Console.ReadLine() ?? string.Empty ?? string.Empty;

            bool deptFound = false;

            Console.WriteLine("Patients in department '" + searchDept.ToUpper() + "':");
            Console.WriteLine("----------------------------------------");

            for (int i = 0; i < patientNames.Count; i++)
            {
                if (departments[i].ToLower().Contains(searchDept.ToLower()))
                {
                    deptFound = true;
                    string status = admitted[i] ? "Admitted" : "Not Admitted"; 

                    string diagDisplay = diagnoses[i];
                    if (diagDisplay.Length > 15)
                    {
                        diagDisplay = diagDisplay.Substring(0, 15) + "...";
                    }

                    // Print patient info
                    Console.WriteLine(
                        "ID: " + patientIDs[i] +
                        " | Name: " + patientNames[i] +
                        " | Diagnosis: " + diagDisplay +
                        " | Blood type: " + bloodType[i] +
                        " | Status: " + status
                    );
                }
            }

            if (deptFound == false)
            {
                Console.WriteLine("No patients found in this department");
            }
        }

        static public void BillingReport()
        {
            Console.WriteLine("Billing Menu");
            Console.WriteLine("1. System-wide total");
            Console.WriteLine("2. Individual patient");
            Console.Write("Enter your choice: ");

            int billChoice = 0;
            try
            {
                billChoice = int.Parse(Console.ReadLine() ?? string.Empty ?? string.Empty);
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
            }

            switch (billChoice)
            {
                case 1:
                    double total = 0;

                    double maxBilling = double.MinValue;
                    double minBilling = double.MaxValue;

                    for (int i = 0; i < patientNames.Count; i++)
                    {
                        total += billingAmount[i];

                        maxBilling = Math.Max(maxBilling, billingAmount[i]);

                        minBilling = Math.Min(minBilling, billingAmount[i]);
                    }

                    
                    Console.WriteLine("Total system billing: " + Math.Round(total, 2) + " OMR");

                    Console.WriteLine("Highest individual billing: " + Math.Round(maxBilling, 2) + " OMR");
                    Console.WriteLine("Lowest individual billing: " + Math.Round(minBilling, 2) + " OMR");

                    break;

                case 2:

                    Console.Write("Enter patient ID or name: ");
                    string billingInput = Console.ReadLine() ?? string.Empty;

                    int bilingFound = searchPatient(billingInput);

                    if (bilingFound == -1)
                    {
                        Console.WriteLine("No billing records found for this patient");
                    }
                    else
                    {
                        
                        double originalBill = billingAmount[bilingFound];

                        Random rnd = new Random();
                        int discountPercent = rnd.Next(5, 21);

                        
                        double discountAmount = (originalBill * discountPercent) / 100;
                        double finalBill = originalBill - discountAmount;

                        
                        Console.WriteLine("Original Billing Amount: " + originalBill + " OMR");
                        Console.WriteLine("Discount Applied: " + discountPercent + "%");
                        Console.WriteLine("Discounted Total: " + Math.Round(finalBill, 2) + " OMR");

                        
                        Console.WriteLine("Last Visit Date: " + lastVisitDate[bilingFound]);
                        Console.WriteLine("Total Days spent in hospital: " + daysInHospital[bilingFound]);
                    }

                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again");
                    break;
            }
        }

        static public void AddDoctor()
        {
            
            Console.Write("Enter Doctor Full Name: ");
            string doctorName = Console.ReadLine() ?? string.Empty.Trim();

            
            if (!string.IsNullOrEmpty(doctorName))
            {
                doctorName = char.ToUpper(doctorName[0]) + doctorName.Substring(1);
            }

            Console.Write("Enter number of available slots: ");
            string slotInput = Console.ReadLine() ?? string.Empty;

            int slots;

            if (!int.TryParse(slotInput, out slots))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return;
            }
            else if (slots < 1)
            {
                Console.WriteLine("Slots must be greater than 0.");
                return;
            }
            else
            {
                
                Console.WriteLine("Slots accepted: " + slots);
            }

            // Check for duplicate doctor (case-insensitive)
            for (int i = 0; i < patientNames.Count; i++)
            {
                if (!string.IsNullOrEmpty(doctorNames[i]) && doctorNames[i].Equals(doctorName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Doctor already exists in the system.");
                    return;
                }
            }

            // Add doctor

            doctorNames.Add(doctorName);
            doctorAvailableSlots.Add(slots);
            doctorVisitCount.Add(0);

            Console.WriteLine("Doctor " + doctorName + " registered successfully with " + slots + " available slots.");
        }


        static public void DoctorSalaryReport()
        {
            Console.WriteLine("Doctor Salary Report");
            Console.WriteLine("----------------------------------------");

            if (doctorNames.Count == 0)
            {
                Console.WriteLine("No doctors registered in the system.");
                return;
            }

            double maxSalary = 0;
            int maxIndex = 0;

            for (int i = 0; i < patientNames.Count; i++)
            {
                const double BASE_SALARY = 300;   
                const double PAY_PER_VISIT = 15;  

                double salary = BASE_SALARY + (doctorVisitCount[i] * PAY_PER_VISIT);
                salary = Math.Round(salary, 2);

                Console.WriteLine(
                    doctorNames[i] +
                    " | Visits: " + doctorVisitCount[i] +
                    " | Available Slots: " + doctorAvailableSlots[i] +
                    " | Salary: " + Convert.ToString(salary) + " OMR"
                );

                // Track highest salary
                if (salary > maxSalary)
                {
                    maxSalary = Math.Max(maxSalary, salary);
                    maxIndex = i;
                }
            }

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Highest earning doctor: " + doctorNames[maxIndex] + " — " + maxSalary + " OMR");
        }
        static public void ExitSystem()
        {
            Console.WriteLine("Exiting system...");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("are you sure you want to exit?(yes/no)");
            string wantExit = Console.ReadLine() ?? string.Empty;

            if (wantExit == "no")
            {
                exit = false;
            }
            else
            {
                exit = true;
                Console.WriteLine("Thank you for using the Healthcare Management System!");
            }
        }
       
        static void Main(string[] args)

        {

            seedData();

            while (exit == false)
            {
                displayMenu();

                Console.Write("Choose option: ");

                int choice = 0;

                try
                {

                    choice = int.Parse(Console.ReadLine() ?? string.Empty);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Invalid input. Please choose a number from 1 to 10.");
                }

                switch (choice)
                {

                    case 1: // Register New Patient

                        registerPatient();

                        break;

                    case 2: // Admit Patient
                        Console.Write("Enter Patient ID or Name: ");
                        string admitInput = Console.ReadLine() ?? string.Empty;

                        int admitIndex = searchPatient(admitInput);

                        if (admitIndex == -1)
                         {
                            Console.WriteLine("Patient not found");
                         }
                        else
                         {
                            AdmitPatient(admitIndex);
                         }

                        break;



                    case 3: // Discharge Patient

                        Console.Write("Enter Patient ID or Name: ");
                        string dischargeInput = Console.ReadLine() ?? string.Empty;

                        int dischargeIndex = searchPatient(dischargeInput);

                        if (dischargeIndex == -1)
                        {
                            Console.WriteLine("Patient not found");
                        }
                        else
                        {
                            DischargePatient(dischargeIndex); 
                        }

                        break;




                    case 4: // Search Patient

                            Console.Write("Enter Patient ID or Name: ");
                            string searchInput = Console.ReadLine() ?? string.Empty;

                            int pateintFound = searchPatient(searchInput);

                        if (pateintFound == -1)
                        {
                            Console.WriteLine("Patient not found");
                        }
                        else
                        {

                            printPatientInfo(pateintFound);
                        }


                            break;


                   case 5: // List All Admitted Patients
                    
                        ShowAdmittedPatients(); 
                        
                        break;


                    case 6: // Transfer Patient to Another Doctor

                        TransferPatient();

                        break;



                    case 7: // View Most Visited Patients
                    
                        ViewMostVisitedPatients();
                        
                        break;

                    case 8: // Search Patients by Department
       
                       SearchByDepartment();

                        break;

                    case 9: // Billing Report
                        
                        BillingReport();
                        
                         break;

                    case 10: // Add Doctor
                        
                        AddDoctor();

                        break;


                        case 11: // Doctor Salary Report

                         DoctorSalaryReport();
                        
                        break;

                    case 12: // Exit
                        
                           ExitSystem();
                        
                        break;

                    default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }


            }
        }
    }


