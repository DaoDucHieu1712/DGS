export interface Login {
  email: string;
  password: string;
}

export interface User {
  id: string;
  displayName: string;
  roles: string[];
  accessToken: string;
  refreshToken: string;
}
