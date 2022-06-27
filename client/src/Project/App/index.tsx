import Preact, { useState } from 'preact/compat';

import { Main } from 'Features/Main';
import { Chat } from 'Features/Chat';
import { Footer } from 'Features/Footer';

import './styles.scss';

const pages = {
  main: 'main',
  chat: 'chat',
};

export const App: Preact.FC = () => {
  const [page, setPage] = useState(pages.main);

  const Header = () => {
    return (
      <header>
        <button onClick={() => setPage(pages.main)}>Main</button>
        <button onClick={() => setPage(pages.chat)}>Chat</button>
      </header>
    );
  };

  const Page: Preact.FC = () => {
    switch (page) {
      case pages.main:
        return <Main />;
      case pages.chat:
        return <Chat />;
      default:
        return <></>;
    }
  };

  return (
    <>
      <header></header>
      <Header />
      <Page />
      <Footer />
    </>
  );
};
