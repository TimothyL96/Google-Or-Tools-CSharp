using System;
using Google.OrTools.LinearSolver;

namespace Google_Or_Tools
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            // GLOP = Google's linear programming system
            // SCIP = Solving Constraint Integer Programs
            Solver solver = Solver.CreateSolver("SCIP");

            // Variables
            Variable teamOf2 = solver.MakeIntVar(0, 1, "teamOf2");
            Variable teamOf3 = solver.MakeIntVar(0, 2, "teamOf3");
            Variable teamOf4 = solver.MakeIntVar(0, 1, "teamOf4");

            Console.WriteLine("Number of variables = " + solver.NumVariables());

            // Constraints
            solver.Add(2 * teamOf2 + 3 * teamOf3 + 4 * teamOf4 <= 5);

            // Function
            solver.Maximize(2 * teamOf2 + 3 * teamOf3 + 4 * teamOf4);
            Console.WriteLine("");

            // Solve
            Solver.ResultStatus resultStatus = solver.Solve();

            // Result
            if (resultStatus != Solver.ResultStatus.OPTIMAL)
            {
                Console.WriteLine("The problem does not have an optimal solution!");
                return;
            }

            Console.WriteLine("Solution:");
            Console.WriteLine("Objective value = " + solver.Objective().Value());
            Console.WriteLine("team Of 2 = " + teamOf2.SolutionValue());
            Console.WriteLine("team Of 3 = " + teamOf3.SolutionValue());
            Console.WriteLine("team Of 4 = " + teamOf4.SolutionValue());
        }
    }
}
