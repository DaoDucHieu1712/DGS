import axiosConfig from "./axiosConfig";

const DashboardService = {
  getChart(): Promise<any> {
    const url = "/Dashboard/Chart";
    return axiosConfig.get(url);
  },
  getDashboard(): Promise<any> {
    const url = "/Dashboard/Total";
    return axiosConfig.get(url);
  },
};

export default DashboardService;
