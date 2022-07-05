import { ApplicationUser } from "./application-user";
import { MenuWithRole } from "./menu";

export interface UserForLogged {
  token: string;
  user: ApplicationUser;
  menus: MenuWithRole[]
}