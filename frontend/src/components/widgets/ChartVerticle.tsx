"use client";
import DashboardService from "@/services/dashboardService";
import { faker } from "@faker-js/faker";
import {
  BarElement,
  CategoryScale,
  Chart as ChartJS,
  Legend,
  LinearScale,
  Title,
  Tooltip,
} from "chart.js";
import { useEffect, useState } from "react";
import { Bar } from "react-chartjs-2";

ChartJS.register(
  CategoryScale,
  LinearScale,
  BarElement,
  Title,
  Tooltip,
  Legend
);

export const options = {
  responsive: true,
  plugins: {
    legend: {
      position: "top" as const,
    },
    title: {
      display: true,
      text: `Chart with ${Date.now()}`,
    },
  },
};

export const labels = [
  "January",
  "February",
  "March",
  "April",
  "May",
  "June",
  "July",
  "August",
  "September",
  "October",
  "November",
  "December",
];

const ChartVerticle = () => {
  const [dataset, setDataSet] = useState<any>({
    labels,
    datasets: [
      {
        label: "Price in",
        data: labels.map(() => faker.datatype.number({ min: 0, max: 1000 })),
        backgroundColor: "rgba(223, 110, 65, 0.973)",
      },
    ],
  });

  useEffect(() => {
    handleChartApi();
  }, []);

  const handleChartApi = async () => {
    await DashboardService.getChart().then((res) => {
      const data = {
        labels: res.map((item: any) => item.month.toString()),
        datasets: [
          {
            label: "Total Price",
            data: res.map((item: any) => item.totalPrice.toString()),
            backgroundColor: "rgba(223, 110, 65, 0.973)",
          },
        ],
      };
      setDataSet(data);
    });
  };

  return <Bar options={options} data={dataset} />;
};

export default ChartVerticle;
