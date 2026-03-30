using System.Collections.Generic;
using System.Xml.Linq;

namespace HealthCareSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // System Storage

            string[] patientNames = new string[100];
            string[] patientIDs = new string[100];
            string[] diagnoses = new string[100];
            bool[] admitted = new bool[100];       // true = currently admitted
            string[] assignedDoctors = new string[100];
            string[] departments = new string[100];     // e.g. "Cardiology", "Orthopedics"
            int[] visitCount = new int[100];        // how many times admitted
            double[] billingAmount = new double[100];     // total fees owed
            int lastPatientIndex = 0;

            //seed data 

            //Patient 1:

            patientNames[lastPatientIndex] = "Ali Hassan";
            patientIDs[lastPatientIndex] = "P001";
            diagnoses[lastPatientIndex] = "Flu";
            departments[lastPatientIndex] = "General";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            visitCount[lastPatientIndex] = 2;
            billingAmount[lastPatientIndex] = 0;

            lastPatientIndex++;

            //Patient 2:

            patientNames[lastPatientIndex] = "Sara Ahmed";
            patientIDs[lastPatientIndex] = "P002";
            diagnoses[lastPatientIndex] = "Fracture";
            departments[lastPatientIndex] = "Orthopedics";
            admitted[lastPatientIndex] = true;
            assignedDoctors[lastPatientIndex] = "Dr. Noor";
            visitCount[lastPatientIndex] = 4;
            billingAmount[lastPatientIndex] = 0;

            lastPatientIndex++;


            //Patient 3:

            patientNames[lastPatientIndex] = "Omar Khalid";
            patientIDs[lastPatientIndex] = "P003";
            diagnoses[lastPatientIndex] = "Diabetes";
            departments[lastPatientIndex] = "Cardiology";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            visitCount[lastPatientIndex] = 1;
            billingAmount[lastPatientIndex] = 0;

            lastPatientIndex++;

            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("Welcome to healthcare system ");
                Console.WriteLine("1.Register New Patient");
                Console.WriteLine("2.Admit Patient"); 
                Console.WriteLine("3.Discharge Patient"); 
                Console.WriteLine("4.Search Patient"); 
                Console.WriteLine("5.List All Admitted Patients");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1: //Register New Patient

                        lastPatientIndex++;
                        Console.Write("patient Name:");
                        patientNames[lastPatientIndex] = Console.ReadLine();
                        Console.Write("patient ID:");
                        patientIDs[lastPatientIndex] = Console.ReadLine();
                        Console.Write("diagnosis:");
                        diagnoses[lastPatientIndex] = Console.ReadLine();
                        Console.Write("department:");
                        departments[lastPatientIndex] = Console.ReadLine();
                        admitted[lastPatientIndex] = false;
                        assignedDoctors[lastPatientIndex] = "";
                        visitCount[lastPatientIndex] = 0;
                        billingAmount[lastPatientIndex] = 0;
                        Console.WriteLine("Patient registered successfully!");

                        break;

                    case 2: // Admit Patient

                        Console.Write("Enter patient ID or name: ");
                        string admitInput = Console.ReadLine();

                        int foundIndex = -1;

                        
                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientNames[i] == admitInput || patientIDs[i] == admitInput)
                            {
                                foundIndex = i;
                                break;
                            }
                        }

                        
                        if (foundIndex == -1)
                        {
                            Console.WriteLine("Patient not found");
                            break ;
                            
                        }

               
                        if (admitted[foundIndex] == true)
                        {
                            Console.WriteLine("Patient is admitted under " + assignedDoctors[foundIndex]);
                            visitCount[foundIndex]++;
                            billingAmount[foundIndex] = 0;
                            break;
                        }

                        break;

                    case 3: // Discharge Patient

                        Console.Write("Enter patient ID or name: ");
                        string Input = Console.ReadLine();
                        int FoundIndex = -1;


                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientNames[i] == Input || patientIDs[i] == Input)
                            {
                                FoundIndex = i;
                                break;
                            }
                        }


                        if (FoundIndex == -1)
                        {
                            Console.WriteLine("Patient not found");
                            break;

                        }


                        if (admitted[FoundIndex] == true)
                        {
                            Console.WriteLine("Patient is admitted under " + assignedDoctors[FoundIndex]);
                            Console.Write("Was there a consultation fee? (yes/no): ");
                            string consultAnswer = Console.ReadLine();
                            if (consultAnswer == "yes")
                            {
                                Console.Write("Enter consultation fee amount: ");
                                int consultFee = int.Parse(Console.ReadLine());

                                billingAmount[FoundIndex] += consultFee;
                            }
                            else
                            {
                                Console.WriteLine("there is no consultation fee");
                                break;
                                
                            }

                            Console.Write("Any medication charges? (yes/no): ");
                            string medAnswer = Console.ReadLine();

                            if (medAnswer == "yes")
                            {
                                Console.Write("Enter medication amount: ");
                                int medFee = int.Parse(Console.ReadLine());

                                billingAmount[FoundIndex] += medFee;
                            }

                            else
                            {
                                Console.WriteLine("there is no medication charges");
                            }
                        }

                        if (billingAmount[FoundIndex] > 0)
                        {
                            Console.WriteLine("Total charges added this visit: " + billingAmount[FoundIndex]);
                        }
                        else
                        {
                            Console.WriteLine("No charges recorded for this visit");
                        }

        

                        break;

                    case 4: //Search Patient
                        Console.Write("Enter patient ID or name: ");
                        string input = Console.ReadLine();

                        int FOUNDIndex = -1;
                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientNames[i] == input || patientIDs[i] == input)
                            {
                                FOUNDIndex = i;
                                break;
                            }
                        }

                        if (FOUNDIndex == -1)
                        {
                            Console.WriteLine("Patient not found");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Patient Details:");
                            Console.WriteLine("Name: " + patientNames[FOUNDIndex]);
                            Console.WriteLine("ID: " + patientIDs[FOUNDIndex]);
                            Console.WriteLine("Diagnosis: " + diagnoses[FOUNDIndex]);
                            Console.WriteLine("Department: " + departments[FOUNDIndex]);
                        }
                        if (admitted[FOUNDIndex] == true)
                        {
                            Console.WriteLine("Status: Admitted");
                            Console.WriteLine("Assigned Doctor: " + assignedDoctors[FOUNDIndex]);
                        }
                        else
                        {
                            Console.WriteLine("Status: Not Admitted");
                        }

                        Console.WriteLine("Visit Count: " + visitCount[FOUNDIndex]);
                        Console.WriteLine("Total Billing Amount: " + billingAmount[FOUNDIndex]);

                        break;
                        

                    case 5: // List All Admitted Patients
                        Console.WriteLine("admitted patients:");
                        bool hasAdmitted = false;
                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (admitted[i] == true)
                            {
                                Console.WriteLine("patient name : " + patientNames[i] + " | patient ID: " + patientIDs[i] + " | Diagnosis: " + diagnoses[i] + " | Department: " + departments[i]+ "|Assigned Doctor:"+assignedDoctors);
                                hasAdmitted = true;
                            }
                        }
                        if (hasAdmitted == false)
                        {
                            Console.WriteLine("No patients currently admitted");
                        }

                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                    case 10:
                        break;









                }
            }


        }
    }
}

