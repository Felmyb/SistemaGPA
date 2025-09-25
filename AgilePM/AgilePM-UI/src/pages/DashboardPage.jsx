import { Sidebar } from "../components/sidebar";
import { DashboardStats } from "../components/dashboard-stats";
import { initialUsersData } from "./UsersPage";
import { initialTasksData } from "./TasksPage";
import { initialProjectsData } from "./ProjectsPage";

function DashboardPage() {
  // Datos reales
  const usersCount = initialUsersData.length;
  const tasksCount = initialTasksData.length;
  const projectsCount = initialProjectsData ? initialProjectsData.length : 0;
  const completedTasks = initialTasksData.filter(t => t.status === "Completada").length;

  // Puedes agregar más cálculos aquí

  const stats = [
    {
      title: "Proyectos Activos",
      value: projectsCount,
      change: "",
      icon: "FolderKanban",
      color: "text-chart-1",
      trend: "",
    },
    {
      title: "Usuarios",
      value: usersCount,
      change: "",
      icon: "Users",
      color: "text-chart-2",
      trend: "",
    },
    {
      title: "Tareas Completadas",
      value: completedTasks,
      change: "",
      icon: "CheckSquare",
      color: "text-chart-3",
      trend: "",
    },
    // ...otros stats
  ];

  return (
    <div className="flex h-screen bg-background">
      <Sidebar />
      <main className="flex-1 md:ml-64 overflow-auto">
        <div className="p-6 md:p-8">
          <h2 className="text-2xl font-bold mb-4">Dashboard</h2>
          <DashboardStats stats={stats} />
        </div>
      </main>
    </div>
  );
}

export default DashboardPage;
