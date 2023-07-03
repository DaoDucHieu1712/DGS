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
      <section className="px-7 py-2 my-6">{children}</section>
      <Footer></Footer>
    </>
  );
}
