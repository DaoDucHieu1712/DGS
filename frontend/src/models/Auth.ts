export interface Login {
  email: string;
  password: string;
}

export interface User {
  email: string;
  roles: string[];
  accessToken: string;
}

export interface ApplicationUser {
  id: string;
  displayName: string;
  gender: boolean;
  birthDay: Date;
  imageUrl: string;
}
