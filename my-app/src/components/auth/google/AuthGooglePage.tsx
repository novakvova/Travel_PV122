import {useEffect} from "react";

const AuthGooglePage = () => {

    const handleGoogleComplete = (resp: any) => {
        const {credential} = resp;
        console.log("-------Google auth----------- ", credential)
    }

    useEffect(() => {
        window.google.accounts!.id.initialize({
            client_id: "763864234936-s953ounakf8bemdaqva8hlao2dai2dj5.apps.googleusercontent.com",
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
