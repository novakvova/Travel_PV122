import {useEffect} from "react";

const AuthGooglePage = () => {

    const handleGoogleComplete = (resp: any) => {
        const {credential} = resp;
        console.log("-------Google auth----------- ", credential)
    }

    useEffect(() => {
        window.google.accounts!.id.initialize({
            client_id: "1092898852465-68g9krvqvqh66uf3o3abbm2av1sgqhtk.apps.googleusercontent.com",
            callback: handleGoogleComplete
        });

        window.google.accounts.id.renderButton(
            document.getElementById("customBtn"),
            {
                theme: "outline",
                size: 'large',
                type: 'icon',
                width: "40"
                //text: "signin",
                //locale: "uk-ua"
            
            });
    },[]);

    return (
      <>
          <h1>Google Auth</h1>
          <div id="customBtn">Вхід</div>
      </>
    );
}

export default AuthGooglePage;
