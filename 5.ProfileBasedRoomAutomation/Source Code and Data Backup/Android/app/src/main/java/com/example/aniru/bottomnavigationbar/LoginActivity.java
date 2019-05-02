package com.example.aniru.bottomnavigationbar;


import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.content.Intent;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import android.content.Intent;
import android.widget.ProgressBar;
import android.os.AsyncTask;
import android.text.TextUtils;
import android.widget.ProgressBar;
import org.json.JSONException;
import org.json.JSONObject;
import java.util.HashMap;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;


public class LoginActivity extends AppCompatActivity {

    EditText editTextEmail, editTextPassword;
    private ProgressBar progressBar;
 
    private FirebaseAuth auth;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);


        //Get Firebase auth instance
        auth = FirebaseAuth.getInstance();

        if (auth.getCurrentUser() != null) {
            startActivity(new Intent(LoginActivity.this, MainActivity.class));
            finish();
        }

        editTextEmail =  findViewById(R.id.login_email);
        editTextPassword = findViewById(R.id.login_password);
        progressBar = findViewById(R.id.progressBar);



        auth = FirebaseAuth.getInstance();


        findViewById(R.id.btn_login).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                final String login_email = editTextEmail.getText().toString().trim();
                final String login_password = editTextPassword.getText().toString().trim();
                //userLogin();

                FirebaseDatabase database = FirebaseDatabase.getInstance();

                DatabaseReference myRef8 = database.getReference("override");
                myRef8.setValue(1);

                if (TextUtils.isEmpty(login_email)) {
                    editTextEmail.setError("Please enter your email");
                    editTextEmail.requestFocus();
                    return;
                }

                if (!android.util.Patterns.EMAIL_ADDRESS.matcher(login_email).matches()) {
                    editTextEmail.setError("Enter a valid email");
                    editTextEmail.requestFocus();
                    return;
                }

                if (TextUtils.isEmpty(login_password)) {
                    editTextPassword.setError("Enter a password");
                    editTextPassword.requestFocus();
                    return;
                }
                progressBar.setVisibility(View.VISIBLE);

                auth.signInWithEmailAndPassword(login_email,login_password).addOnCompleteListener(LoginActivity.this, new OnCompleteListener<AuthResult>() {
                            @Override
                            public void onComplete(@NonNull Task<AuthResult> task) {
                                // If sign in fails, display a message to the user. If sign in succeeds
                                // the auth state listener will be notified and logic to handle the
                                // signed in user can be handled in the listener.
                                progressBar.setVisibility(View.GONE);
                                final FirebaseAuth mAuth = FirebaseAuth.getInstance();

                                if (task.isSuccessful()) {
                                    // Sign in success, update UI with the signed-in user's information
                                   //Log.d(TAG,"signInWithEmail:success");

                                    FirebaseUser user = mAuth.getCurrentUser();

                                    if (user.isEmailVerified()) {
                                        //Toast.makeText(LoginActivity.this, "Verfied Email", Toast.LENGTH_LONG).show();
                                        Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                                        startActivity(intent);
                                    } else {
                                        Toast.makeText(LoginActivity.this, "Please Verfied Email First", Toast.LENGTH_LONG).show();
                                        return;
                                    }


                                } else {

                                    // If sign in fails, display a message to the user.
                                    // Log.w(TAG, "signInWithEmail:failure", task.getException());
                                    Toast.makeText(LoginActivity.this, "Authentication failed. Please check Email/Password", Toast.LENGTH_SHORT).show();
                                    return;
                                }


                            }
                        });

            }
        });

        findViewById(R.id.link_forgotPassword).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(LoginActivity.this, ResetPasswordActivity.class));
            }
        });

        findViewById(R.id.link_signup).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //open register screen
                finish();
                startActivity(new Intent(getApplicationContext(), SignupActivity.class));
            }
        });

    }


}