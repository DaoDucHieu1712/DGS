import Nav from "@/components/layout/Nav";
import SideBar from "@/components/layout/SideBar";

export default function LayoutMain({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <SideBar></SideBar>
      <section className="px-7 py-2 ml-[300px]">
        <Nav></Nav>
        <div className="mt-10">{children}</div>
      </section>
    </>
  );
}
