export interface Startup {
  id: string;
  name: string;
  businessDomain: string;
  description: string;
  grossSales: number;
  netSales: number;
  businessStartDate: Date;
  website: string;
  businessLocation: string;
  employeeCount: number;
  founderId: string;
  founderName: string;
  created: string;
  updated: string;
}

export interface Founder {
  id: string;
  name: string;
  email: string;
  token: string;
}
