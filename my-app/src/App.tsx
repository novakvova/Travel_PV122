import './App.css'
import HomePage from "./Pages/home/HomePage";
import AuthGooglePage from './components/AuthGooglePage';
import Slaider from "./components/Slaider";
function App() {


  return (
    <>
      <Slaider></Slaider>
      <HomePage></HomePage>
      <AuthGooglePage></AuthGooglePage>
    </>
  )
}

export default App
