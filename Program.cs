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

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
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

