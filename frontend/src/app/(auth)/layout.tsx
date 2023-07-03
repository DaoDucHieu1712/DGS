import Footer from "@/components/Footer";
import Header from "@/components/Header";

export default function LayoutMain({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <>
      <Header></Header>
      <section className="p-7">{children}</section>
      <Footer></Footer>
    </>
  );
}
