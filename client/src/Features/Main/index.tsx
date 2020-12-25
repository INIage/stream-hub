import Preact, { useRef } from 'preact/compat';
import { useDispatch, useSelector } from 'react-redux';

import { action, selector } from 'Foundation/GoodGame/User';

import { login } from './api';

import './styles.scss';

export const Main: Preact.FC = () => {
  const dispatch = useDispatch();
  const GGUser = useSelector(selector.GetUser);

  const usernameRef = useRef<HTMLInputElement>();
  const passwordRef = useRef<HTMLInputElement>();

  return (
    <main id="main">
      {!GGUser ? (
        <div class="form">
          <span>GGLogin!</span>
          <input ref={usernameRef} type="text" />
          <input ref={passwordRef} type="password" />
          <button
            onClick={() => {
              login(usernameRef.current.value, passwordRef.current.value).then(data =>
                dispatch(action.SetUser(data.user)),
              );
            }}
          >
            login
          </button>
        </div>
      ) : (
        <div class="form">
          <span>You are logged!</span>
        </div>
      )}
    </main>
  );
};
