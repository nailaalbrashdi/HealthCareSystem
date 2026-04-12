using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HealthCareSystem
{
    internal class Program
    {

        // System Storage

        static string[] patientNames = new string[100];
        static string[] patientIDs = new string[100];
        static string[] diagnoses = new string[100];
        static bool[] admitted = new bool[100];
        static string[] assignedDoctors = new string[100];
        static string[] departments = new string[100];
        static int[] visitCount = new int[100];
        static double[] billingAmount = new double[100];


        static DateTime[] lastVisitDate = new DateTime[100];
        static DateTime[] lastDischargeDate = new DateTime[100];
        static int[] daysInHospital = new int[100];
        static string[] bloodType = new string[100];
        static int lastIndex = 0;

        static public void seedData()
        {


            
            patientNames[lastIndex] = "Ali Hassan";
            patientIDs[lastIndex] = "P001";
            diagnoses[lastIndex] = "Flu";
            departments[lastIndex] = "General";
            admitted[lastIndex] = false;
            assignedDoctors[lastIndex] = "";
            visitCount[lastIndex] = 2;
            billingAmount[lastIndex] = 0;
            lastVisitDate[lastIndex] = new DateTime(2025, 01, 10);
            lastDischargeDate[lastIndex] = new DateTime(2025, 01, 15);
            daysInHospital[lastIndex] = 12;
            bloodType[lastIndex] = "A+";

            lastIndex++;

            patientNames[lastIndex] = "Sara Ahmed";
            patientIDs[lastIndex] = "P002";
            diagnoses[lastIndex] = "Fracture";
            departments[lastIndex] = "Orthopedics";
            admitted[lastIndex] = true;
            assignedDoctors[lastIndex] = "Dr. Noor";
            visitCount[lastIndex] = 4;
            billingAmount[lastIndex] = 0;
            lastVisitDate[lastIndex] = new DateTime(2025, 03, 02);
            lastDischargeDate[lastIndex] = new DateTime();
            daysInHospital[lastIndex] = 8;
            bloodType[lastIndex] = "O-";

            lastIndex++;

            patientNames[lastIndex] = "Omar Khalid";
            patientIDs[lastIndex] = "P003";
            diagnoses[lastIndex] = "Diabetes";
            departments[lastIndex] = "Cardiology";
            admitted[lastIndex] = false;
            assignedDoctors[lastIndex] = "";
            visitCount[lastIndex] = 1;
            billingAmount[lastIndex] = 0;
            lastVisitDate[lastIndex] = new DateTime(2024, 12, 20);
            lastDischargeDate[lastIndex] = new DateTime(2024, 12, 28);
            daysInHospital[lastIndex] = 5;
            bloodType[lastIndex] = "B+";


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
            Console.WriteLine("10. Exit");
        }

        static public string registerPatient(string patientNames,string diagnoses,string bloodType,string department )
        {
            patientIDs[lastIndex] = "P" + (lastIndex + 1).ToString("D3");
            admitted[lastIndex] = false;
            assignedDoctors[lastIndex] = "";
            visitCount[lastIndex] = 0;
            billingAmount[lastIndex] = 0;
            lastVisitDate[lastIndex] = new DateTime();
            lastDischargeDate[lastIndex] = new DateTime();
            daysInHospital[lastIndex] = 0;

            return patientIDs[lastIndex];
        }
        static public int searchPatient(string searchInput)
        {
            int pateintFound = -1;


            for (int i = 0; i <= lastIndex; i++)
            {
                if (patientNames[i] == searchInput || patientIDs[i] == searchInput)
                {
                    pateintFound = i;
                    break;


                }

            }
            return pateintFound;
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
        

            static void Main(string[] args)
            
            {

                seedData();

 
                bool exit = false;

                while (exit == false)
                {
                    displayMenu();

                    Console.Write("Choose option: ");

                    int choice = 0;

                    try
                    {

                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Invalid input. Please choose a number from 1 to 10.");
                    }

                    switch (choice)
                    {

                        case 1: // Register New Patient

                            lastIndex++;
                            Console.Write("Patient Name: ");
                            patientNames[lastIndex] = Console.ReadLine().Trim();


                            Console.Write("Diagnosis: ");
                            diagnoses[lastIndex] = Console.ReadLine().Trim();

                            Console.Write("Enter Blood Type: ");
                            bloodType[lastIndex] = Console.ReadLine().ToUpper();

                            Console.Write("Department: ");
                            departments[lastIndex] = Console.ReadLine().Trim();

                            string PID=registerPatient(patientNames[lastIndex], diagnoses[lastIndex], bloodType[lastIndex], departments[lastIndex]);

                            Console.WriteLine("Patient registered successfully with ID :" +PID);


                            break;

                        case 2: // Admit Patient
                            Console.Write("Enter Patient ID or Name: ");
                            string admitInput = Console.ReadLine();

                            bool admitFound = false;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (patientNames[i] == admitInput || patientIDs[i] == admitInput)
                                {
                                    admitFound = true;

                                    if (admitted[i] == false)
                                    {
                                        Console.Write("Doctor Name: ");
                                        assignedDoctors[i] = Console.ReadLine();
                                        DateTime AdmissionDate = DateTime.Now;
                                        lastVisitDate[i] = AdmissionDate;
                                        Console.WriteLine("Admission Date : " + AdmissionDate.ToString("yyyy - MM - dd HH: mm"));

                                        admitted[i] = true;
                                        visitCount[i]++;

                                        Console.WriteLine("Patient admitted successfully and assigned to " + assignedDoctors[i]);


                                        if (visitCount[i] > 1)
                                            Console.WriteLine("This patient has been admitted " + visitCount[i] + " times");
                                        else
                                            Console.WriteLine("this is first time");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Patient is already admitted under " + assignedDoctors[i]);
                                    }

                                    break;
                                }
                            }

                            if (admitFound == false)
                            {
                                Console.WriteLine("Patient not found");
                            }

                            break;

                        case 3: // Discharge Patient
                            Console.Write("Enter Patient ID or Name: ");
                            string dischargeInput = Console.ReadLine();

                            bool dischargeFound = false;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (patientNames[i] == dischargeInput || patientIDs[i] == dischargeInput)
                                {
                                    dischargeFound = true;

                                    if (admitted[i] == true)
                                    {
                                        double visitCharges = 0;

                                        Console.Write("Was there a consultation fee? (yes/no): ");
                                        string hasFee = Console.ReadLine().ToLower();

                                        if (hasFee == "yes")
                                        {
                                            Console.Write("Enter consultation fee amount: ");

                                            double fee = 0;
                                            try
                                            {
                                                fee = double.Parse(Console.ReadLine());
                                                if (fee > 0)
                                                {

                                                    fee = Math.Round(fee, 2);
                                                    billingAmount[i] = Math.Round(billingAmount[i] + fee, 2);
                                                    visitCharges += fee;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("fee amount must be posititve");
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Invalid amount. Please enter a valid number.");
                                            }

                                        }

                                        Console.Write("Any medication charges? (yes/no): ");
                                        string hasMeds = Console.ReadLine().ToLower();

                                        if (hasMeds == "yes")
                                        {
                                            Console.Write("Enter medication charges amount: ");
                                            double meds = 0;
                                            try
                                            {
                                                meds = double.Parse(Console.ReadLine());
                                                if (meds > 0)
                                                {
                                                    meds = Math.Round(meds, 2);
                                                    billingAmount[i] = Math.Round(billingAmount[i] + meds, 2);
                                                    visitCharges += meds;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("medication charges must be positive");
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Invalid amount.Please enter a valid number.");
                                            }

                                        }

                                        if (visitCharges > 0)
                                        {
                                            Console.WriteLine("Total charges added this visit: " + visitCharges + " OMR");
                                        }
                                        else
                                        {
                                            Console.WriteLine("No charges recorded for this visit");
                                        }

                                        admitted[i] = false;
                                        assignedDoctors[i] = "";

                                        Console.Write("Enter Discharge Date : ");
                                        string dischargeDate = Console.ReadLine();
                                        lastDischargeDate[i] = DateTime.Parse(dischargeDate);
                                        Console.Write("enter the number of days spent in hospital during this visit: ");
                                        daysInHospital[i] = int.Parse(Console.ReadLine());
                                        Console.Write("Total days in hospital :" + daysInHospital[i]);
                                        Console.WriteLine("Patient discharged successfully!");

                                    }
                                    else
                                    {
                                        Console.WriteLine("This patient is not currently admitted");
                                    }

                                    break;
                                }
                            }

                            if (dischargeFound == false)
                            {
                                Console.WriteLine("Patient not found");
                            }

                            break;




                        case 4: // Search Patient

                            Console.Write("Enter Patient ID or Name: ");
                            string searchInput = Console.ReadLine();

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
                            Console.WriteLine("Currently Admitted Patients:");
                            Console.WriteLine("Filter by name keyword (press Enter to skip):");
                            string nameFilter = Console.ReadLine();
                            Console.WriteLine("----------------------------------------");

                            bool hasAdmitted = false;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (admitted[i] == true)
                                {
                                    Console.WriteLine("Name: " + patientNames[i] + " | ID: " + patientIDs[i] + " | Diagnosis: " + diagnoses[i] + " | Department: " + departments[i] + " | Doctor: " + assignedDoctors[i] + "| Admitted Since: " + lastVisitDate[i].ToString("yyyy - MM - dd"));
                                    hasAdmitted = true;
                                    if (visitCount[i] > 1)
                                        Console.WriteLine("This patient has been admitted " + visitCount[i] + " times");
                                    else
                                        Console.WriteLine("this is first time");

                                }
                            }

                            break;

                        case 6: // Transfer Patient to Another Doctor
                            Console.Write("Enter current doctor name: ");
                            string currentDoctor = Console.ReadLine().Trim().Replace("Dr ", "Dr.");

                            Console.Write("Enter new doctor name: ");
                            string newDoctor = Console.ReadLine().Trim().Replace("Dr ", "Dr.");

                            bool doctorFound = false;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (assignedDoctors[i] == currentDoctor && admitted[i] == true)
                                {
                                    doctorFound = true;
                                    assignedDoctors[i] = newDoctor;

                                    if (currentDoctor != newDoctor)
                                    {
                                        Console.WriteLine("Patient '" + patientNames[i] + "' has been transferred from " + currentDoctor + " to " + newDoctor);
                                        Console.WriteLine("Patient last admitted on: " + lastVisitDate[i]);
                                    }

                                    else
                                    {
                                        Console.WriteLine("should current doctor name not same new doctor name");
                                    }
                                    break;

                                }
                            }

                            if (doctorFound == false)
                            {
                                Console.WriteLine("No admitted patients found under this doctor");
                            }

                            break;

                        case 7: // View Most Visited Patients
                            Console.WriteLine("Most Visited Patients (by visit count):");
                            Console.WriteLine("----------------------------------------");

                            int[] tempVisits = new int[100];

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                tempVisits[i] = visitCount[i];
                            }

                            for (int pass = 0; pass <= lastIndex; pass++)
                            {
                                int maxIndex = 0;

                                for (int i = 0; i <= lastIndex; i++)
                                {
                                    if (tempVisits[i] > tempVisits[maxIndex])
                                    {
                                        maxIndex = i;
                                    }
                                }

                                Console.WriteLine("ID: " + patientIDs[maxIndex] + " | Name: " + patientNames[maxIndex] + " | Visits: " + tempVisits[maxIndex]);

                                tempVisits[maxIndex] = -1;
                            }

                            break;


                        case 8: // Search Patients by Department
                            Console.Write("Enter department name: ");
                            string searchDept = Console.ReadLine();

                            bool deptFound = false;

                            Console.WriteLine("Patients in department '" + searchDept.ToUpper() + "':");
                            Console.WriteLine("----------------------------------------");

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (departments[i].ToLower().Contains(searchDept.ToLower()))
                                {
                                    deptFound = true;
                                    string status = admitted[i] ? "Admitted" : "Not Admitted"; //ternary operator

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

                            break;

                        case 9: // Billing Report
                            Console.WriteLine("Billing Menu");
                            Console.WriteLine("1. System-wide total");
                            Console.WriteLine("2. Individual patient");
                            Console.Write("Enter your choice: ");
                            int billChoice = 0;
                            try
                            {
                                billChoice = int.Parse(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid input. Please enter 1 or 2.");
                            }

                            switch (billChoice)
                            {
                                case 1:
                                    double total = 0;

                                    for (int i = 0; i <= lastIndex; i++)
                                    {
                                        total += billingAmount[i];
                                    }

                                    Console.WriteLine("Total system billing: " + total);
                                    break;

                                case 2:
                                    
                                Console.Write("Enter patient ID or name: ");
                                string billingInput = Console.ReadLine();

                                int bilingFound = searchPatient(billingInput); // call the search function (returns true if found, false if not   


                                if (bilingFound == -1)
                                  {

                                    Console.WriteLine(" No billing records found for this patient");

                                  }

                                else
                                  {
                                    Console.WriteLine("Total billing amount: " + billingAmount[lastIndex]);
                                    Console.WriteLine("Last Visit Date: " + lastVisitDate[lastIndex]);
                                    Console.WriteLine("Total Days spent in hospital: " + daysInHospital[lastIndex]);

                                   }
                                    

                                    break;
                                
                            
                                   default:

                                    Console.WriteLine("Invalid option. Please try again");

                                    break;

                            }
                            break;

                        case 10: // Exit
                            Console.WriteLine("Exiting system...");
                            Console.WriteLine("----------------------------------------");

                            Console.WriteLine("are you sure you want to exit?(yes/no)");
                            string wantExit = Console.ReadLine();
                            if (wantExit == "no")
                            {
                                exit = false;
                            }
                            else
                            {
                                exit = true;
                                Console.WriteLine("Thank you for using the Healthcare Management System!");
                            }
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


