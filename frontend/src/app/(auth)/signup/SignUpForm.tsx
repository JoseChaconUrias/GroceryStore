import React from 'react'

const SignUpForm = () => {
  return (
    <form className='outline w-[29rem] p-14 text-center rounded-xl'>
        <h1 className='text-2xl font-bold mb-2'>Welcome to (Our store name)!</h1>
        <h2 className='text-xl font-bold mb-10'>Sign Up Start Shopping</h2>
        <div className='flex flex-col items-center'>
            <input className='outline p-2 rounded-xl w-full mb-3'placeholder='Full Name' type="text" required/>
            <input className='outline p-2 rounded-xl w-full mb-3' placeholder='Email Address' type="text" required/>
            <input className='outline p-2 rounded-xl w-full mb-3'placeholder='Username' type ="text" required/>
            <input className='outline p-2 rounded-xl w-full mb-3'placeholder='Password' type='text' required/>
            <input className='outline p-2 rounded-xl w-full mb-5' placeholder='Confirm Password'type="text" required/>

            <button className='rounded-3xl font-bold bg-emerald-400 w-32 p-2'>Sign Up</button>
        </div>
    </form>
  )
}

export default SignUpForm