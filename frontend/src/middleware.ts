import { NextRequest, NextResponse } from "next/server";

export async function middleware(req: NextRequest) {
  //Check if user logged in -> Yes: redirect to home
  if (
    req.nextUrl.pathname.startsWith("/register") ||
    req.nextUrl.pathname.startsWith("/login")
  ) {
    if (req.cookies.has("token")) {
      return NextResponse.redirect(new URL("/", req.url));
    }
  }
  //Check if user logged in -> No: redirect to /login ok
  if (
    req.nextUrl.pathname.startsWith("/cart") ||
    req.nextUrl.pathname.startsWith("/dashboard") ||
    req.nextUrl.pathname.startsWith("/my-order") ||
    req.nextUrl.pathname.startsWith("/profile") ||
    req.nextUrl.pathname.startsWith("/change-password")
  ) {
    if (!req.cookies.has("token")) {
      return NextResponse.redirect(new URL("/login", req.url));
    }
  }
  //Check role user
  if (
    req.nextUrl.pathname.startsWith("/dashboard") ||
    req.nextUrl.pathname.startsWith("/product") ||
    req.nextUrl.pathname.startsWith("/order") ||
    req.nextUrl.pathname.startsWith("/user") ||
    req.nextUrl.pathname.startsWith("/category")
  ) {
    if (req.cookies.get("roles")?.value === "Admin") {
      return NextResponse.redirect(new URL("/access-denied", req.url));
    }
  }
  //
}
